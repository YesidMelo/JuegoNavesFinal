using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorStopMovementPlayer : BaseMotorMovementPlayer
{
    private GameObject _currentMotor;
    private int _speedMotor;

    public MotorStopMovementPlayer(
        GameObject currentMotor,
        int speedMotor
    ) {
        _currentMotor = currentMotor;
        _speedMotor = speedMotor;
    }

    public void move(){}
}
