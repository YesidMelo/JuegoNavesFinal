using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractSpacecraft : MonoBehaviour
{
    public Spacecraft currentSpaceCraft = Spacecraft.SPACECRAFT_1;
    public GameObject laser;
    public GameObject motor;
    public GameObject radar;
    public GameObject shield;
    public GameObject structure;
    public GameObject storage;

    protected void Awake() => initListeners();

    public AbstractSpacecraft updateLaser(List<Laser> currentLaser) {
        HandlerLaser handler = laser.GetComponent<HandlerLaser>();
        handler.updateLasers(currentLaser);
        initListenerLaser();
        return this;
    }

    public AbstractSpacecraft updateMotor(Motor currentMotor) {
        HandlerMotor handler = motor.GetComponent<HandlerMotor>();
        handler.updateMotor(currentMotor);
        initListenerMotor();
        return this;
    }

    public AbstractSpacecraft updateRadar(Radar currentRadar) {
        HandlerRadar handler = radar.GetComponent<HandlerRadar>();
        handler.updateRadar(currentRadar);
        initListenerRadar();
        return this;
    }

    public AbstractSpacecraft updateShield(List<Shield> currentShield) {
        HanderShield hander = shield.GetComponent<HanderShield>();
        hander.updateListShields(currentShield);
        initListenerShield();
        return this;
    }
    public AbstractSpacecraft updateStorage(Storage currentStorage) {
        HandlerStorage handler = storage.GetComponent<HandlerStorage>();
        handler.updateStorage(currentStorage);
        initListenerStorage();
        return this;
    }

    public AbstractSpacecraft updateStructure(Structure currentStructure) {
        HandlerStructure handler = structure.GetComponent<HandlerStructure>();
        handler.updateStructure(currentStructure);
        initListenerStructure();
        return this;
    }

    // delegates
    private void initListeners() {
        initListenerLaser();
        initListenerMotor();
        initListenerRadar();
        initListenerShield();
        initListenerStorage();
        initListenerStructure();
    }


    private void initListenerLaser() {
        HandlerLaser handler = laser.GetComponent<HandlerLaser>();
        handler.myDelegate = new HandlerLaserListener(this);
    }

    private void initListenerMotor() {
        HandlerMotor handler = motor.GetComponent<HandlerMotor>();
        handler.myDelegate = new HandlerMotorListener(this);
    }

    private void initListenerRadar()
    {
        HandlerRadar handler = radar.GetComponent<HandlerRadar>();
        handler.myDelegate = new HandlerRadarListener(this);
    }

    private void initListenerShield() {
        HanderShield hander = shield.GetComponent<HanderShield>();
        hander.myDelegate = new HandlerShieldListener(this);
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
