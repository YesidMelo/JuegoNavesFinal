using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerMotorsEnemyViewModelDelegate {
    void notifyLoadCurrentSpacecraft();
    void notifyLoadMotor();

}
public interface HandlerMotorsEnemyViewModel { 

    SpacecraftEnemy currrentSpacecraft { get; }
    HandlerMotorsEnemyViewModelDelegate myDelegate { get; set; }
    void loadSpacecraft(IdentificatorModel identificator);

}

public class HandlerMotorsEnemyViewModelImpl : HandlerMotorsEnemyViewModel
{
    private SpacecraftEnemyGetCurrentSpacecraftUseCase currentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private HandlerMotorsEnemyViewModelDelegate _myDelegate;

    public SpacecraftEnemy currrentSpacecraft => _currentSpacecraft;

    public HandlerMotorsEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public void loadSpacecraft(IdentificatorModel identificator)
    {
        _currentSpacecraft = currentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
    }
}