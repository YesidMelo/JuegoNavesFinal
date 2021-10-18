using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLaserEnemy : MonoBehaviour, HandlerLaserEnemyViewModelDelegate
{
    public List<LaserEnemy> listLasers;
    public bool updateLasers = false;
    public bool loadLasers = false;
    public GameObject prefabLaserEnemy;
    public bool startShoot = false;

    private HandlerLaserEnemyViewModel viewModel = new HandlerLaserEnemyViewModelImpl();
    private IdentificatorModel _currentIdentificator;
    private DetailLaserEnemy _detailLaserEnemy;
    private bool coroutineStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        updateListLasersUIUnity();
        loadListLasersUIUnity();
        shoot();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.name.Contains(Constants.nameAmmunitionLaserEnemy)) return;
        GameObject currentLaser = collision.transform.gameObject;
        HandlerAmmounitionLaserEnemy handler = currentLaser.GetComponent<HandlerAmmounitionLaserEnemy>();
        HandlerAmmounitionLaserEnemy tmp = handler;
        if (handler.detailLaser.parent != transform.gameObject) return;

        Destroy(currentLaser);
    }

    //public methods
    public void updateListLasers(IdentificatorModel identificator, List<LaserEnemy> listLasers) {
        if (viewModel == null) return;
        viewModel.deleteLasers(_currentIdentificator);
        if (_currentIdentificator != identificator) _currentIdentificator = identificator;
        viewModel.addListLasers(_currentIdentificator, listLasers);
    }

    //private methods

    private void shoot()
    {
        if (!startShoot) return;
        if (coroutineStarted) return;
        coroutineStarted = true;
        StartCoroutine(generateLaser());
    }

    //ienumerator methods
    IEnumerator generateLaser() {
        if (_detailLaserEnemy == null) {
            startShoot = false;
            coroutineStarted = false;
            yield return null;
        }
        while (startShoot) {
            GameObject laser = Instantiate(prefabLaserEnemy);
            laser.transform.position = transform.position;
            laser.transform.eulerAngles = transform.eulerAngles - new Vector3(0, 0, -90);

            HandlerAmmounitionLaserEnemy handler = laser.transform.GetComponent<HandlerAmmounitionLaserEnemy>();
            if (handler == null) break;
            handler.laserSelected = viewModel.impactLaser;
            handler.updateDetailLaser(_detailLaserEnemy);
            yield return new WaitForSeconds(Constants.speedFiring);
        }
        coroutineStarted = false;
        yield return null;
    }
    //ui unity methods
    private void updateListLasersUIUnity() {
        if (!updateLasers) return;
        updateLasers = false;
        if (listLasers == null || listLasers.Count == 0) return;
        if (_currentIdentificator == null) _currentIdentificator = new IdentificatorModel();
        updateListLasers(_currentIdentificator, listLasers);
    }

    private void loadListLasersUIUnity() {
        if (!loadLasers) return;
        loadLasers = false;
        if (listLasers == null || listLasers.Count == 0) return;
        if (_currentIdentificator == null) _currentIdentificator = new IdentificatorModel();
        viewModel.loadListLasers(_currentIdentificator);
    }

    //delegate methods
    public void notifyLoadLasers()
    {
        listLasers = viewModel.listLasers;
        if (_detailLaserEnemy == null) _detailLaserEnemy = new DetailLaserEnemy();
        _detailLaserEnemy.parent = transform.gameObject;
        _detailLaserEnemy.nameParent = transform.name;
    }
}
