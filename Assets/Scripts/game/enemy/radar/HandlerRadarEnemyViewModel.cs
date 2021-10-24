using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerRadarEnemyViewModelDelegate {
    void notifyLoadCurrentSpacecraft();
    void notifyLoadRadar();
}

public interface HandlerRadarEnemyViewModel { 
    SpacecraftEnemy currentSpacecraft { get; }
    HandlerRadarEnemyViewModelDelegate myDelegate { get; set; }
    void loadSpacecraft(IdentificatorModel identificator);
}

public class HandlerRadarEnemyViewModelImpl : HandlerRadarEnemyViewModel
{

    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private SpacecraftEnemy _currentSpacecraft;
    private HandlerRadarEnemyViewModelDelegate _myDelegate;

    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerRadarEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public void loadSpacecraft(IdentificatorModel identificator)
    {
        _currentSpacecraft = getCurrentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
    }
}