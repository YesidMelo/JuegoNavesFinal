using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface HandlerLaserDelegate {}

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
    private HandlerLaserViewModel _viewModel;


    void Start()
    {
        selectContext();
        _viewModel.setListLasers(lasersType);
        lasersType = _viewModel.listLasers;

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
        _viewModel.setListLasers(lasersType);
        contextLaser.updateLasers(lasersType);
    }

    public void deleteLasers() => _viewModel.deleteLasers();

    //private methods
    
    private IEnumerator generateLaser() {
        while (contextLaser.shooting) {
            GameObject laser = Instantiate(prefabLaser);
            laser.transform.position = transform.position;
            laser.transform.eulerAngles = transform.eulerAngles;
            HandlerAmmunitionLaser handler = laser.transform.GetChild(0).GetComponent<HandlerAmmunitionLaser>();

            if (handler == null) break;
            contextLaser.finalLaser.parent = transform.parent.gameObject;
            handler.laserSelected = _viewModel.finalLaser;
            contextLaser.finalLaser.impactDamage = _viewModel.mediaImpactLaser;
            handler.changeAmmountLaser(contextLaser.finalLaser);

            yield return new WaitForSeconds(Constants.speedFiring);
        }
        yield return null;
    }

    private void selectContext() {
        if (contextLaser != null) {
            return;
        }
        GameObject parent = transform.parent.parent.gameObject;
        if (parent.name.Contains(Constants.nameEnemy))
        {
            createComponentsEnemy();
            return;
        }
        createComponentPlayer();
    }

    void createComponentsEnemy() {
        _viewModel = new HandlerLaserEnemyViewModelImpl();
        contextLaser = new ContextLaserEnemy(
            lasers: lasers,
            lasersType: lasersType,
            myDelegate: this,
            gameObject: transform.gameObject
        );
    }

    void createComponentPlayer() {
        _viewModel = new HandlerLaserPlayerViewModelImpl();
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
