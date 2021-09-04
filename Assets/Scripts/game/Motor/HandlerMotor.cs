using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerMotorDelegate { }

public class HandlerMotor : MonoBehaviour
{
    private HandlerMotorDelegate _delegate;

    public Motor currentMotorType = Motor.TYPE_1;
    public AbstractMotor currentMotor;

    public HandlerMotorDelegate myDelegate { set { _delegate = value; } }

    private void Awake() => initMotor();

    public void updateMotor(Motor currentMotor) {
        currentMotorType = currentMotor;
        initMotor();
    }

    // private methods

    private void initMotor() {
        currentMotor = (new MotorFactory()).getMotor(currentMotorType);
    }
}
