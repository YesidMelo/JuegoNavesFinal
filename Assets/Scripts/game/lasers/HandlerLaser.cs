using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface HandlerLaserDelegate { }

public class HandlerLaser : MonoBehaviour
{
    [Range(1, 5)]
    public int maxLasers = 1;
    [Range(1, 5)]
    public int minLasers = 1;
    public List<Laser> lasersType = new List<Laser>();
    public List<AbstractLaser> lasers = new List<AbstractLaser>();
    public HandlerLaserDelegate myDelegate { set { _myDelegate = value; } }
    public GameObject prefabLaser;
    
    private CurrentActionSpacecraftUseCase _currentActionSpacecraftUseCase = new CurrentActionSpacecraftUseCaseImpl();
    private AbstractLaser finalLaser;
    private HandlerLaserDelegate _myDelegate;
    private bool shooting = false;
    private Thread shootThread;
    private IEnumerator corutineShoot;


    void Start()
    {
        initLasersDefaults();
        calculateFinalValueLaser();
    }

    private void Update()
    {
        checkShoot();
    }

    //Public methods
    public void updateLasers(List<Laser> currentLasers) {
        lasersType = currentLasers;
        initLasersDefaults();
        calculateFinalValueLaser();
    }

    // private methods
    private void initLasersDefaults() {
        lasers.Clear();
        foreach (Laser currentLaser in lasersType) {
            lasers.Add((new LaserFactory()).getLaser(currentLaser));
        }
    }

    private void calculateFinalValueLaser() {
        if (lasersType == null || lasersType.Count == 0) return;
        float finalValue = 0;
        for (int index = 0; index< lasersType.Count; index++) {
            AbstractLaser currentLaser = generateLaser(lasersType[index]);
            finalValue = finalValue + currentLaser.impactDamage;
        }
        finalLaser = new LaserFinal();
        finalLaser.impactDamage = finalValue;
    }

    private AbstractLaser generateLaser(Laser laser) {
        switch (laser) {
            case Laser.TYPE_2:
                return new LaserType2();
            case Laser.TYPE_3:
                return new LaserType3();
            case Laser.TYPE_4:
                return new LaserType4();
            case Laser.TYPE_5:
                return new LaserType5();
            case Laser.TYPE_1:
            default:
                return new LaserType1();
        }
    }

    private void checkShoot() {
        GameObject parent = transform.parent.parent.gameObject;
        if (parent.name.Contains(Constants.nameEnemy)) {
            shootEnemy();
            return;
        }
        shootPlayer();
    }

    private void shootEnemy()
    {
    }

    private void shootPlayer() {
        if (_currentActionSpacecraftUseCase.invoke() != Action.ATTACK) {
            shooting = false;
            return; 
        }
        if (shooting) { return; }
        shooting = true;
        corutineShoot = generateLaser();
        StartCoroutine(corutineShoot);
    }

    private IEnumerator generateLaser() {
        while (shooting) {
            GameObject laser = Instantiate(prefabLaser);
            laser.transform.position = transform.position;
            laser.transform.eulerAngles = transform.eulerAngles;
            HandlerAmmunitionLaser handler = laser.transform.GetChild(0).GetComponent<HandlerAmmunitionLaser>();

            if (handler == null) break;
            finalLaser.parent = transform.parent.gameObject;
            handler.laserSelected = getFinalLaser();
            handler.changeAmmountLaser(finalLaser);

            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }

    private Laser getFinalLaser() {
        Laser laserSelected;
        float totalAttack = finalLaser.impactDamage / lasersType.Count;
        if (totalAttack <= Constants.laserType1) {
            laserSelected = Laser.TYPE_1;
        } else if (totalAttack < Constants.laserType1 && totalAttack <= Constants.laserType2 ) {
            laserSelected = Laser.TYPE_2;
        } else if (totalAttack < Constants.laserType2 && totalAttack <= Constants.laserType3 ) {
            laserSelected = Laser.TYPE_3;
        } else if (totalAttack < Constants.laserType3 && totalAttack <= Constants.laserType4 ) {
            laserSelected = Laser.TYPE_4;
        } else {
            laserSelected = Laser.TYPE_5;
        }
        return laserSelected;
    }
}
