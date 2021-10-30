using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerRadarEnemyViewModelDelegate {
    void notifyLoadCurrentSpacecraft();
    void notifyLoadRadar();
}

public interface HandlerRadarEnemyViewModel { 
    SpacecraftEnemy currentSpacecraft { get; }
    RadarEnemy currentRadar { get; }
    int currentRadiusRadar { get; }

    HandlerRadarEnemyViewModelDelegate myDelegate { get; set; }
    void loadSpacecraft(IdentificatorModel identificator);
}

public class HandlerRadarEnemyViewModelImpl : HandlerRadarEnemyViewModel
{

    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private SpacecraftEnemyLoadRadarUseCase loadRadarUseCase = new SpacecraftEnemyLoadRadarUseCaseImpl();
    private SpacecraftEnemyCurrentRadarUseCase currentRadarUseCase = new SpacecraftEnemyCurrentRadarUseCaseImpl();
    private SpacecraftEnemyCurrentRadiusRadarUseCase currentRadiusRadarUseCase = new SpacecraftEnemyCurrentRadiusRadarUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private HandlerRadarEnemyViewModelDelegate _myDelegate;
    private RadarEnemy _currentRadar;
    private int _currentRadiusRadar;
    private IdentificatorModel identificatorModel;

    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerRadarEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public RadarEnemy currentRadar => _currentRadar;

    public int currentRadiusRadar => _currentRadiusRadar;

    public void loadSpacecraft(IdentificatorModel identificator)
    {
        identificatorModel = identificator;
        _currentSpacecraft = getCurrentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
        loadRadar();
    }

    //private methods
    private void loadRadar() {
        if (identificatorModel == null) return;
        if (!loadRadarUseCase.invoke(identificatorModel)) return;
        _currentRadar = currentRadarUseCase.invoke(identificatorModel);
        _currentRadiusRadar = currentRadiusRadarUseCase.invoke(identificatorModel) ;
        _myDelegate.notifyLoadRadar();
    }
}