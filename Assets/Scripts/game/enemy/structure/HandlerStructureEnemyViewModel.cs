using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerStructureEnemyViewModelDelegate {
    void notifyLoadSpacecraft();
    void notifyLoadScructure();
}

public interface HandlerStructureEnemyViewModel {
    SpacecraftEnemy currentSpacecraft { get; }
    HandlerStructureEnemyViewModelDelegate myDelegate { get; set; }

    void loadSpacecraft(IdentificatorModel identificator);
}
public class HandlerStructureEnemyViewModelImpl : HandlerStructureEnemyViewModel
{
    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private HandlerStructureEnemyViewModelDelegate _myDelegate;

    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerStructureEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public void loadSpacecraft(IdentificatorModel identificator)
    {
        _currentSpacecraft = getCurrentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadSpacecraft();
    }
}