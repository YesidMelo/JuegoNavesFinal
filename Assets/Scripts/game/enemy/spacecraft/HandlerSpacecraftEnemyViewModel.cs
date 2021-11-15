using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerSpacecraftEnemyViewModelDelegate {
    void notifyLoadEnemy();
}

public interface HandlerSpacecraftEnemyViewModel {
    HandlerSpacecraftEnemyViewModelDelegate myDelegate { get; set; }
    IdentificatorModel identificator { get; }
    SpacecraftEnemy currentSpacecraft { get; }
    void loadSpacecraft();
    void setSpacecraft(SpacecraftEnemy spacecraft);
    void destroySpacecraft();
}

public class HandlerSpacecraftEnemyViewModelImpl : HandlerSpacecraftEnemyViewModel
{
    private SpacecraftEnemyLoadSpacecraftUseCase loadSpacecraftUseCase = new SpacecraftEnemyLoadSpacecraftUseCaseImpl();
    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private SpacecraftEnemySetSpacecraftUseCase setSpacecraftUseCase = new SpacecraftEnemySetSpacecraftUseCaseImpl();
    private SpacecraftEnemyDestroySpacecraftUseCase destroySpacecraftUseCase = new SpacecraftEnemyDestroySpacecraftUseCaseImpl();

    private HandlerSpacecraftEnemyViewModelDelegate _myDelegate;
    private IdentificatorModel _identificator = new IdentificatorModel();
    private SpacecraftEnemy _currentSpacecraft = SpacecraftEnemy.NIVEL1_SECOND_LIEUTENANTS;

    //gets and sets
    public HandlerSpacecraftEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public IdentificatorModel identificator { 
        get => _identificator; 
    }

    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public void destroySpacecraft() => destroySpacecraftUseCase.invoke(_identificator);

    public void loadSpacecraft()
    {
        bool load = loadSpacecraftUseCase.invoke(identificator);
        if (!load) return;
        _currentSpacecraft = getCurrentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadEnemy();
    }

    public void setSpacecraft(SpacecraftEnemy spacecraft)
    {
        setSpacecraftUseCase.invoke(identificator, spacecraft);
        loadSpacecraft();
    }
}