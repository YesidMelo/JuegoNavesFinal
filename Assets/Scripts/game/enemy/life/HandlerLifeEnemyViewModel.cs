using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLifeEnemyViewModelDelegate {
    void notifyLoadCurrentSpacecraft();
    void notifyLoadCurrentLife();
}

public interface HandlerLifeEnemyViewModel {
    SpacecraftEnemy currentSpacecraft { get; }
    HandlerLifeEnemyViewModelDelegate myDelegate { get; set; }
    void loadCurrentSpacecraft(IdentificatorModel identificator);


}

public class HandlerLifeEnemyViewModelImpl : HandlerLifeEnemyViewModel
{

    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();

    private SpacecraftEnemy _spacecraftEnemy;
    private HandlerLifeEnemyViewModelDelegate _myDelegate;

    public SpacecraftEnemy currentSpacecraft => _spacecraftEnemy;

    public HandlerLifeEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value;
    }

    public void loadCurrentSpacecraft(IdentificatorModel identificator)
    {
        _spacecraftEnemy = getCurrentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
    }
}