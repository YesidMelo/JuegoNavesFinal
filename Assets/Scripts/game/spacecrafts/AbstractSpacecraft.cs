using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractSpacecraft : MonoBehaviour
{
    public Spacecraft currentSpaceCraft = Spacecraft.SPACECRAFT_1;
    public GameObject shield;
    public GameObject laser;

    private void Start()
    {
        initListeners();
    }

    // delegates
    private void initListeners() {
        initListenerShield();
        initListenerLaser();
    }

    private void initListenerShield() {
        HanderShield hander = shield.GetComponent<HanderShield>();
        hander.myDelegate = new HandlerShieldListener(this);
    }

    private void initListenerLaser() {
        HandlerLaser handler = laser.GetComponent<HandlerLaser>();
        handler.myDelegate = new HandlerLaserListener(this);
    }
}
