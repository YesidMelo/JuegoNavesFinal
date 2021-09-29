using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface HandlerLaserDelegate { }

public class HandlerLaser : MonoBehaviour, BaseContextLaserDelegate
{
    [Range(1, 5)]
    public int maxLasers = 1;
    [Range(1, 5)]
    public int minLasers = 1;
    public List<Laser> lasersType = new List<Laser>();
    public List<AbstractLaser> lasers = new List<AbstractLaser>();
    public HandlerLaserDelegate myDelegate { set { _myDelegate = value; } }
    public GameObject prefabLaser;

    private BaseContextLaser contextLaser;
    private HandlerLaserDelegate _myDelegate;

    void Start()
    {
        selectContext();
        contextLaser.initLasersDefaults();
        contextLaser.calculateFinalValueLaser();
    }

    private void Update()
    {
        if (contextLaser == null) return;
        contextLaser.shoot();
    }

    //Public methods
    public void updateLasers(List<Laser> currentLasers) {
        lasersType = currentLasers;
        contextLaser.updateLasers(lasersType);
    }

    
    private IEnumerator generateLaser() {
        while (contextLaser.shooting) {
            GameObject laser = Instantiate(prefabLaser);
            laser.transform.position = transform.position;
            laser.transform.eulerAngles = transform.eulerAngles;
            HandlerAmmunitionLaser handler = laser.transform.GetChild(0).GetComponent<HandlerAmmunitionLaser>();

            if (handler == null) break;
            contextLaser.finalLaser.parent = transform.parent.gameObject;
            handler.laserSelected = getFinalLaser();
            handler.changeAmmountLaser(contextLaser.finalLaser);

            yield return new WaitForSeconds(Constants.speedFiring);
        }
        yield return null;
    }
    
    private Laser getFinalLaser() {
        Laser laserSelected;
        float totalAttack = contextLaser.finalLaser.impactDamage / lasersType.Count;
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

    private void selectContext() {
        if (contextLaser != null) {
            return;
        }
        GameObject parent = transform.parent.parent.gameObject;
        if (parent.name.Contains(Constants.nameEnemy))
        {
            contextLaser = new ContextLaserEnemy(
                lasers: lasers,
                lasersType: lasersType,
                myDelegate: this,
                gameObject: transform.gameObject
                
            );
            return;
        }
        contextLaser = new ContextLaserPlayer(
            lasers: lasers,
            lasersType: lasersType,
            myDelegate: this,
            gameObject: transform.gameObject
        );
    }

    public void startCorutine()
    {
        StartCoroutine(generateLaser());
    }
}
