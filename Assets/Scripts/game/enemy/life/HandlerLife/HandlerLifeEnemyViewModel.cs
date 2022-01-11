using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLifeEnemyViewModelDelegate {
    void notifyLoadCurrentSpacecraft();
    void notifyLoadCurrentLife();
}

public interface HandlerLifeEnemyViewModel {

    float currentLife { get; }
    float maxLife { get; }
    SpacecraftEnemy currentSpacecraft { get; }
    HandlerLifeEnemyViewModelDelegate myDelegate { get; set; }
    void loadCurrentSpacecraft(IdentificatorModel identificator);
}

public class HandlerLifeEnemyViewModelImpl : HandlerLifeEnemyViewModel
{

    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private SpacecraftEnemyLoadLifeUseCase loadLifeUseCase = new SpacecraftEnemyLoadLifeUseCaseImpl();
    private SpacecraftEnemyCurrentLifeUseCase currentLifeUseCase = new SpacecraftEnemyCurrentLifeUseCaseImpl();
    private SpacecraftEnemyMaxLifeUseCase maxLifeUseCase = new SpacecraftEnemyMaxLifeUseCaseImpl();

    private SpacecraftEnemy _spacecraftEnemy;
    private HandlerLifeEnemyViewModelDelegate _myDelegate;
    private IdentificatorModel identificatorModel;

    public SpacecraftEnemy currentSpacecraft => _spacecraftEnemy;

    public HandlerLifeEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value;
    }

    public float currentLife {
        get {
            if (identificatorModel == null) return 0;
            return currentLifeUseCase.invoke(identificatorModel);
        }
    }

    public float maxLife {
        get {
            if (identificatorModel == null) return 0;
            return maxLifeUseCase.invoke(identificatorModel);
        }
    }

    public void loadCurrentSpacecraft(IdentificatorModel identificator)
    {
        identificatorModel = identificator;
        _spacecraftEnemy = getCurrentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
        loadDetailLife();
    }

    //private method
    private void loadDetailLife() {
        if (identificatorModel == null) return;
        if (!loadLifeUseCase.invoke(identificatorModel)) return;
        _myDelegate.notifyLoadCurrentLife();
    }
}