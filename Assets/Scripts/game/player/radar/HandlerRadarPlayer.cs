using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRadarPlayer : MonoBehaviour, HandlerRadarPlayerViewModelDelegate
{
    public bool loadRadarFromUI = false;
    public bool updateRadarFromUI = false;
    public List<GameObject> listObjectsInRadar = new List<GameObject>();
    public RadarPlayer currentRadar = RadarPlayer.TYPE_2;
    public float currentRadius = 2f;
    public GameObject parent;

    private HandlerRadarPlayerViewModel viewModel = new HandlerRadarPlayerViewModelImpl();
    
    void Start()
    {
        viewModel.myDelegate = this;
        viewModel.loadRadar();
    }

    void Update()
    {
        if (viewModel.isGameInPause()) return;
        loadRadarFromUIUnity();
        updateCurrentRadarFromUIUnity();
        checkCurrentObjects();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!checkGameobjectCollision(collision)) return;
        viewModel.addElementToRadar(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!checkGameobjectCollision(collision)) return;
        viewModel.removeElementFromRadar(collision.gameObject);
    }

    //public methods
    public void updateCurrentRadar(RadarPlayer radarPlayer) {
        if (viewModel == null) return;
        viewModel.updateCurrentRadar(radarPlayer);
    }

    //private methods
    private void checkCurrentObjects() {
        if (viewModel == null) return;
        listObjectsInRadar = viewModel.listObjects;
    }

    private void checkCurrentRadiusRadar() {
        CircleCollider2D currentCollider = GetComponent<CircleCollider2D>();
        currentCollider.radius = currentRadius;
    }

    private bool checkGameobjectCollision(Collider2D collision) {
        if (viewModel == null) return false;
        if (collision.name.Contains(Constants.nameLaserEnemy)) return false;
        if (collision.name.Contains(Constants.nameRadarEnemy)) return false;
        if (collision.name.Contains(Constants.nameAmmunitionLaserEnemy)) return false;
        if (collision.name.Contains(Constants.nameLaserPlayer)) return false;
        if (collision.name.Contains(Constants.nameShieldPlayer)) return false;
        return true;
    }

    //ui methods
    private void loadRadarFromUIUnity() {
        if (!loadRadarFromUI) return;
        loadRadarFromUI = false;
        viewModel.loadRadar();
    }

    private void updateCurrentRadarFromUIUnity() {
        if (!updateRadarFromUI) return;
        updateRadarFromUI = false;
        updateCurrentRadar(currentRadar);
    }

    //delegates
    public void notifyLoadRadar()
    {
        currentRadar = viewModel.currentRadar;
        currentRadius = viewModel.currentRadiusRadar;
        checkCurrentRadiusRadar();
    }

}
