using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorStopMovementPlayer : BaseMotorMovementPlayer
{
    private GameObject _currentMotor;
    private float _speedMotor;

    public MotorStopMovementPlayer(
        GameObject currentMotor,
        float speedMotor
    ) {
        _currentMotor = currentMotor;
        _speedMotor = speedMotor;
    }

    public void move(){}

    public void updateSpeedMotor(float speedMotor) {
        _speedMotor = speedMotor;
    }
}
