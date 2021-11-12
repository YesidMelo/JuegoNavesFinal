using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorFordwardMovementPlayer : BaseMotorMovementPlayer
{
    private GameObject _currentMotor;
    private float _speedSpacecraft;
    public MotorFordwardMovementPlayer(
        GameObject currentMotor,
        float speedSpacecraft
    ) {
        _currentMotor = currentMotor;
        _speedSpacecraft = speedSpacecraft;
    }

    public void move() {
        Debug.Log(string.Format("{0} : {1}", "velocidad actual", _speedSpacecraft));
        _currentMotor.transform.Translate(0, _speedSpacecraft * Time.deltaTime, 0); 
    }

    public void updateSpeedMotor(float speedMotor) {
        if (speedMotor == 0) return;
        _speedSpacecraft = speedMotor;
    }
}
