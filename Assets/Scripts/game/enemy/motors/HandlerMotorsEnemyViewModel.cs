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
    int currentSpeed { get; }
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
    private int _currentSpeed = 0;
    private MotorEnemy _currentMotor = MotorEnemy.TYPE_1;
    private IdentificatorModel identificatorModel;


    public SpacecraftEnemy currrentSpacecraft => _currentSpacecraft;

    public HandlerMotorsEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public MotorEnemy currentMotor => _currentMotor;

    public int currentSpeed => _currentSpeed;

    public void loadSpacecraft(IdentificatorModel identificator)
    {
        identificatorModel = identificator;
        _currentSpacecraft = currentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
        loadMotor();
    }

    //private methods
    private void loadMotor() {
        if (identificatorModel == null) return;
        if (!loadMotorUseCase.invoke(identificatorModel)) return;
        _currentMotor = currentMotorUseCase.invoke(identificatorModel);
        _currentSpeed = currentSpeedUseCase.invoke(identificatorModel);
        _myDelegate.notifyLoadMotor();
    }
}