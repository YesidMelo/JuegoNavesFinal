using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractSpacecraft : MonoBehaviour
{
    public Spacecraft currentSpaceCraft = Spacecraft.SPACECRAFT_1;
    public GameObject shield;
    public GameObject laser;
    public GameObject radar;
    public GameObject structure;
    public GameObject storage;

    private void Start()
    {
        initListeners();
    }

    // delegates
    private void initListeners() {
        initListenerShield();
        initListenerLaser();
        initListenerStorage();
        initListenerStructure();
        initListenerRadar();
    }

    private void initListenerShield() {
        HanderShield hander = shield.GetComponent<HanderShield>();
        hander.myDelegate = new HandlerShieldListener(this);
    }

    private void initListenerLaser() {
        HandlerLaser handler = laser.GetComponent<HandlerLaser>();
        handler.myDelegate = new HandlerLaserListener(this);
    }

    private void initListenerRadar()
    {
        HandlerRadar handler = radar.GetComponent<HandlerRadar>();
        handler.myDelegate = new HandlerRadarListener(this);
    }

    private void initListenerStorage() {
        HandlerStorage handler = storage.GetComponent<HandlerStorage>();
        handler.myDelegate = new HandlerStorageListener(this);
    }

    private void initListenerStructure() {
        HandlerStructure handler = structure.GetComponent<HandlerStructure>();
        handler.myDelegate = new HandlerStructureListener(this);
    }

   
}
