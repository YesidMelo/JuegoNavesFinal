using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerRadarDelegate {
    void enterGameObject(Collider2D collision);
    void exitGameObject(Collider2D collision);
}

public class HandlerRadar : MonoBehaviour
{
    private HandlerRadarDelegate _myDelegate;
    public HandlerRadarDelegate myDelegate { set { _myDelegate = value; } }
    public Radar currentRadar = Radar.TYPE_1;
    public AbstractRadar radar;

    public List<GameObject> enemy {
        get {
            if (radar == null) {
                return new List<GameObject>();
            }
            return radar.listEnemy;
        }
    }

    public GameObject currentEnemy {
        get {
            if (radar == null) {
                return null;
            }
            return radar.currentEnemy;
        }
    }

    public void changeEnemy() {
        if (radar == null) { return; }
        radar.changeEnemy();
    }

    private void Awake()
    {
        createRadar();
    }

    private void Start()
    {
        if (radar == null) {
            return;
        }
        radar.currentSideGameObject = transform.parent.parent.name;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (radar == null || _myDelegate == null) {return;}
        radar.addSideEnemy(collision);
        _myDelegate.enterGameObject(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(radar == null || _myDelegate == null) { return; }
        radar.removeEnemy(collision.gameObject);
        _myDelegate.enterGameObject(collision);
    }

    //public methods
    public void updateRadar(Radar currentRadar) {
        this.currentRadar = currentRadar;
        createRadar();
    }

    // private methods

    private void createRadar() => radar = (new RadarFactory()).getRadar(currentRadar);
}
