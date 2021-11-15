using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLaserPlayer : MonoBehaviour, HandlerLaserPlayerViewModelDelegate
{

    public List<LaserPlayer> listLasers;
    public bool updateLasersFromUI = false;
    public GameObject prefabLaserPlayer;
    public GameObject parent;
    public float currentImpact;

    private HandlerLaserPlayerViewModel viewModel = new HandlerLaserPlayerViewModelImpl();
    private Action _currentActionSpacecraft;
    private DetailLaserPlayer _detailLaserPlayer;
    private bool coroutineStarted = false;


    void Start()
    {
        viewModel.myDelegate = this;
        viewModel.loadLasers();        
    }

    // Update is called once per frame
    void Update()
    {
        updateLasersFromUIUnity();
        checkCurrentActionSpacecraft();
        startActionSpacecraft();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.name.Contains(Constants.nameAmmunitionLaserPlayer)) return;
        Destroy(collision.transform.gameObject);
    }


    //Public Methods
    public void updateLasers(List<LaserPlayer> listLasers) {
        if (viewModel == null) return;
        viewModel.calculateLasers(listLasers);
        viewModel.loadLasers();
    }

    //Private Methods

    private void checkCurrentActionSpacecraft() => _currentActionSpacecraft = viewModel.currentAction;
    private void startActionSpacecraft() {
        if (_currentActionSpacecraft != Action.ATTACK) return;
        if (coroutineStarted) return;
        coroutineStarted = true;
        StartCoroutine(generateLaser());
    }

    //IEnumerator Methods
    IEnumerator generateLaser() {
        while (viewModel.shooting) {
            GameObject laser = Instantiate(prefabLaserPlayer);
            laser.transform.position = transform.position;
            laser.transform.eulerAngles = transform.eulerAngles - new Vector3(0,0,-90);
            HandlerAmmountLaserPlayer handler = laser.transform.GetComponent<HandlerAmmountLaserPlayer>();

            if (handler == null) break;
            handler.laserSelected = viewModel.typeLaser;
            handler.updateDetailLaser(_detailLaserPlayer);
            yield return new WaitForSeconds(Constants.speedFiring);
        }
        coroutineStarted = false;
        yield return null;
    }

    //UI UnityMethods
    private void updateLasersFromUIUnity() {
        if (!updateLasersFromUI) return;
        updateLasersFromUI = false;
        if (listLasers == null || listLasers.Count == 0) return;
        updateLasers(listLasers);
    }

    //Delegates

    public void lasersLoaded()
    {
        if (_detailLaserPlayer == null) {
            _detailLaserPlayer = new DetailLaserPlayer();
        }
        currentImpact = viewModel.impactDamage;
        _detailLaserPlayer.impactDamage = viewModel.impactDamage;
        _detailLaserPlayer.nameParent = transform.name;
        _detailLaserPlayer.parent = transform.gameObject;
        listLasers = viewModel.listLaser;
    }
}
