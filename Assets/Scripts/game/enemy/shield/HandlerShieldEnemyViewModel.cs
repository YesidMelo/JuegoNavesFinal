using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerShieldEnemyViewModelDelegate {
    void notifyLoadCurrentSpacecraft();
    void notifyLoadShield();
}

public interface HandlerShieldEnemyViewModel {

    SpacecraftEnemy currentSpacecraft { get; }
    HandlerShieldEnemyViewModelDelegate myDelegate { get; set; }

    void loadSpacecraft(IdentificatorModel identificatorModel);

}
public class HandlerShieldEnemyViewModelImpl : HandlerShieldEnemyViewModel
{
    
    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private HandlerShieldEnemyViewModelDelegate _myDelegate;

    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerShieldEnemyViewModelDelegate myDelegate { 
        get =>_myDelegate; 
        set => _myDelegate = value; 
    }

    public void loadSpacecraft(IdentificatorModel identificatorModel)
    {
        _currentSpacecraft = getCurrentSpacecraftUseCase.invoke(identificatorModel);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
    }
}
