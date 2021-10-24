using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerStorageEnemyViewModelDelegate {
    void notifyLoadCurrentSpacecraft();
    void notifyLoadStorage();
}

public interface HandlerStorageEnemyViewModel { 
    SpacecraftEnemy currentSpacecraft { get; }
    HandlerStorageEnemyViewModelDelegate myDelegate { get; set; }
    void loadSpacecraf(IdentificatorModel identificator);
}

public class HandlerStorageEnemyViewModelImpl : HandlerStorageEnemyViewModel
{
    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private SpacecraftEnemy _currentSpacecraft;
    private HandlerStorageEnemyViewModelDelegate _myDelegate;

    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerStorageEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public void loadSpacecraf(IdentificatorModel identificator)
    {
        _currentSpacecraft = getCurrentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
    }
}