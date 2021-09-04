using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovementSpacecraft 
{
    protected GameObject spaceCraftToMove;
    private List<GameObject> _enemy = new List<GameObject>();
    private GameObject _currentEnemy;
    private int _speedSpacecraft;

    protected int speedSpacecraft { 
        get {
            return _speedSpacecraft;
        } 
    }

    protected List<GameObject> enemy {
        get {
            return _enemy;
        }
    }

    protected GameObject currentEnemy
    {
        get {
            return _currentEnemy;
        }
    }

    public AbstractMovementSpacecraft(
        GameObject spaceCraftToMove
    ) {
        this.spaceCraftToMove = spaceCraftToMove;
        loadSpeedSpacecraft();
    }

    public abstract void move();

    protected void loadEnemy() {
        GameObject spacecraft = spaceCraftToMove.transform.FindChild(Constants.nameSpacecraft).gameObject;
        GameObject radar = spacecraft.transform.FindChild(Constants.nameRadar).gameObject;
        HandlerRadar handler = radar.GetComponent<HandlerRadar>();
        _enemy = handler.enemy;
        _currentEnemy = handler.currentEnemy;
    }

    private void loadSpeedSpacecraft() {
        GameObject spacecraft = spaceCraftToMove.transform.FindChild(Constants.nameSpacecraft).gameObject;
        GameObject motor = spacecraft.transform.FindChild(Constants.nameMotor).gameObject;
        HandlerMotor handler = motor.GetComponent<HandlerMotor>();
        AbstractMotor currentMotor = handler.currentMotor;
        _speedSpacecraft = currentMotor.speed;
    }

}
