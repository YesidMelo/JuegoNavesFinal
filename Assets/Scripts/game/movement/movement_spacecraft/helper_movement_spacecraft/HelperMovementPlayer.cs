using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperMovementPlayer : BaseHelperMovementSpacecraft
{
    private CurrentActionSpacecraftUseCase _currentActionSpacecraftUseCase = new CurrentActionSpacecraftUseCaseImpl();

    public HelperMovementPlayer(GameObject spaceCraftToMove) : base(spaceCraftToMove){}

    public override void loadEnemy()
    {
        GameObject spacecraft = spaceCraftToMove.transform.FindChild(Constants.nameSpacecraft).gameObject;
        GameObject radar = spacecraft.transform.FindChild(Constants.nameRadar).gameObject;
        HandlerRadar handler = radar.GetComponent<HandlerRadar>();
        _enemy = handler.objetives;
        _currentEnemy = handler.currentObjetive;
        if (currentEnemy != null && _currentActionSpacecraftUseCase.invoke() != Action.ATTACK) return;
        handler.changeEnemy();
        _enemy = handler.objetives;
        _currentEnemy = handler.currentObjetive;
    }

    public override void loadSpeedSpacecraft()
    {
        GameObject spacecraft = spaceCraftToMove.transform.FindChild(Constants.nameSpacecraft).gameObject;
        GameObject motor = spacecraft.transform.FindChild(Constants.nameMotor).gameObject;
        HandlerMotor handler = motor.GetComponent<HandlerMotor>();
        AbstractMotor currentMotor = handler.currentMotor;
        _speedSpacecraft = currentMotor.speed;
        _speedRotationSpacecraft = currentMotor.speedRotation;
    }
}
