using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerStorageEnemyViewModelDelegate {
    void notifyLoadCurrentSpacecraft();
    void notifyLoadStorage();
}

public interface HandlerStorageEnemyViewModel { 
    SpacecraftEnemy currentSpacecraft { get; }
    StorageEnemy currentStorage { get; }
    HandlerStorageEnemyViewModelDelegate myDelegate { get; set; }
    void loadSpacecraf(IdentificatorModel identificator);
}

public class HandlerStorageEnemyViewModelImpl : HandlerStorageEnemyViewModel
{
    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private SpacecraftEnemyLoadStorageUseCase loadStorageUseCase = new SpacecraftEnemyLoadStorageUseCaseImpl();
    private SpacecraftEnemyCurrentStorageUseCase currentStorageUseCase = new SpacecraftEnemyCurrentStorageUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private HandlerStorageEnemyViewModelDelegate _myDelegate;
    private StorageEnemy _currentStorage;
    private IdentificatorModel identificatorModel;

    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerStorageEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public StorageEnemy currentStorage => _currentStorage;

    public void loadSpacecraf(IdentificatorModel identificator)
    {
        identificatorModel = identificator;
        _currentSpacecraft = getCurrentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
        loadStorage();
    }

    //private methods
    private void loadStorage() {
        if (identificatorModel == null) return;
        if (!loadStorageUseCase.invoke(identificatorModel)) return;
        _currentStorage = currentStorageUseCase.invoke(identificatorModel);
        _myDelegate.notifyLoadStorage();
    }
}