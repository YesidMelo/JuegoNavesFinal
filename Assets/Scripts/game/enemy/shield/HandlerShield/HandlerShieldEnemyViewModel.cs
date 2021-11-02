using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerShieldEnemyViewModelDelegate {
    void notifyLoadCurrentSpacecraft();
    void notifyLoadShield();
}

public interface HandlerShieldEnemyViewModel {

    SpacecraftEnemy currentSpacecraft { get; }
    ShieldEnemy currentShield { get; }
    HandlerShieldEnemyViewModelDelegate myDelegate { get; set; }
    IdentificatorModel identificator{ get; }

    void loadSpacecraft(IdentificatorModel identificatorModel);

}
public class HandlerShieldEnemyViewModelImpl : HandlerShieldEnemyViewModel
{
    
    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private SpacecraftEnemyLoadShieldUseCase loadShieldUseCase = new SpacecraftEnemyLoadShieldUseCaseImpl();
    private SpacecraftEnemyCurrentShieldUseCase currentShieldUseCase = new SpacecraftEnemyCurrentShieldUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private HandlerShieldEnemyViewModelDelegate _myDelegate;
    private ShieldEnemy _currentShield;
    private IdentificatorModel _identificator;

    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerShieldEnemyViewModelDelegate myDelegate { 
        get =>_myDelegate; 
        set => _myDelegate = value; 
    }

    public ShieldEnemy currentShield => _currentShield;

    public IdentificatorModel identificator => _identificator;

    public void loadSpacecraft(IdentificatorModel identificatorModel)
    {
        _identificator = identificatorModel;
        _currentSpacecraft = getCurrentSpacecraftUseCase.invoke(identificatorModel);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
        loadShield();
    }

    //private methods
    private void loadShield() {
        if (_identificator == null) return;
        if (!loadShieldUseCase.invoke(_identificator)) return;
        _currentShield = currentShieldUseCase.invoke(_identificator);
        _myDelegate.notifyLoadShield();
    }
}
