using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerMotorsEnemyViewModelDelegate {
    void notifyLoadCurrentSpacecraft();
    void notifyLoadMotor();

}
public interface HandlerMotorsEnemyViewModel { 

    SpacecraftEnemy currrentSpacecraft { get; }
    MotorEnemy currentMotor { get; }
    float currentSpeed { get; }
    IdentificatorModel identificator { get; }
    HandlerMotorsEnemyViewModelDelegate myDelegate { get; set; }
    void loadSpacecraft(IdentificatorModel identificator);

}

public class HandlerMotorsEnemyViewModelImpl : HandlerMotorsEnemyViewModel
{
    private SpacecraftEnemyGetCurrentSpacecraftUseCase currentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private SpacecraftEnemyLoadMotorUseCase loadMotorUseCase = new SpacecraftEnemyLoadMotorUseCaseImpl();
    private SpacecraftEnemyCurrentMotorUseCase currentMotorUseCase = new SpacecraftEnemyCurrentMotorUseCaseImpl();
    private SpacecraftEnemyCurrentSpeedUseCase currentSpeedUseCase = new SpacecraftEnemyCurrentSpeedUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private HandlerMotorsEnemyViewModelDelegate _myDelegate;
    private float _currentSpeed = 0;
    private MotorEnemy _currentMotor = MotorEnemy.TYPE_1;
    private IdentificatorModel _identificatorModel;


    public SpacecraftEnemy currrentSpacecraft => _currentSpacecraft;

    public HandlerMotorsEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public MotorEnemy currentMotor => _currentMotor;

    public float currentSpeed => _currentSpeed;

    public IdentificatorModel identificator => _identificatorModel;

    public void loadSpacecraft(IdentificatorModel identificator)
    {
        _identificatorModel = identificator;
        _currentSpacecraft = currentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
        loadMotor();
    }

    //private methods
    private void loadMotor() {
        if (_identificatorModel == null) return;
        if (!loadMotorUseCase.invoke(_identificatorModel)) return;
        _currentMotor = currentMotorUseCase.invoke(_identificatorModel);
        _currentSpeed = currentSpeedUseCase.invoke(_identificatorModel);
        _myDelegate.notifyLoadMotor();
    }
}