using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovementSpacecraft 
{
    protected GameObject spaceCraftToMove;
    private int _speedSpacecraft;

    protected int speedSpacecraft { 
        get {
            return _speedSpacecraft;
        } 
    }

    public AbstractMovementSpacecraft(
        GameObject spaceCraftToMove
    ) {
        this.spaceCraftToMove = spaceCraftToMove;
        loadSpeedSpacecraft();
    }

    public abstract void move();

    private void loadSpeedSpacecraft() {
        GameObject spacecraft = spaceCraftToMove.transform.GetChild(0).gameObject;
        GameObject motor = spacecraft.transform.FindChild(Constants.nameMotor).gameObject;
        HandlerMotor handler = motor.GetComponent<HandlerMotor>();
        AbstractMotor currentMotor = handler.currentMotor;
        _speedSpacecraft = currentMotor.speed;
    }

}
