using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorFordwardMovementPlayer : BaseMotorMovementPlayer
{
    private GameObject _currentMotor;
    private int _speedSpacecraft;
    public MotorFordwardMovementPlayer(
        GameObject currentMotor,
        int speedSpacecraft
    ) {
        _currentMotor = currentMotor;
        _speedSpacecraft = speedSpacecraft;
    }

    public void move() => _currentMotor.transform.Translate(0, _speedSpacecraft * Time.deltaTime, 0);
}
