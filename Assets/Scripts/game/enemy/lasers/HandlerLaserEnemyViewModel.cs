using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLaserEnemyViewModelDelegate {
    void notifyLoadSpacecraft();
    void notifyLoadLasers();
}
public interface HandlerLaserEnemyViewModel { 
    SpacecraftEnemy currentSpacecraft { get; }
    HandlerLaserEnemyViewModelDelegate myDelegate { get; set; }
    void loadCurrentSpacecraft(IdentificatorModel identificator);
}
public class HandlerLaserEnemyViewModelImpl : HandlerLaserEnemyViewModel
{
    private SpacecraftEnemyGetCurrentSpacecraftUseCase currentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private HandlerLaserEnemyViewModelDelegate _myDelegate;

    //gets and sets
    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerLaserEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value;
    }

    public void loadCurrentSpacecraft(IdentificatorModel identificator)
    {
        _currentSpacecraft = currentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadSpacecraft();
    }

    


}