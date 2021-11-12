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
    List<GameObject> currentGameobjectInRadar{ get;}
    IdentificatorModel identificator { get; }

    HandlerRadarEnemyViewModelDelegate myDelegate { get; set; }
    void loadSpacecraft(IdentificatorModel identificator);
    void addGameObjectToRadar(GameObject gameObject);
    void removeGameObjectFromRadar(GameObject gameObject);

}

public class HandlerRadarEnemyViewModelImpl : HandlerRadarEnemyViewModel
{

    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private SpacecraftEnemyLoadRadarUseCase loadRadarUseCase = new SpacecraftEnemyLoadRadarUseCaseImpl();
    private SpacecraftEnemyCurrentRadarUseCase currentRadarUseCase = new SpacecraftEnemyCurrentRadarUseCaseImpl();
    private SpacecraftEnemyCurrentRadiusRadarUseCase currentRadiusRadarUseCase = new SpacecraftEnemyCurrentRadiusRadarUseCaseImpl();
    private SpacecraftEnemyAddGameobjectToRadarUseCase addGameobjectToRadarUseCase = new SpacecraftEnemyAddGameobjectToRadarUseCaseImpl();
    private SpacecraftEnemyRemoveGameobjectFromRadarUseCase removeGameobjectFromRadarUseCase = new SpacecraftEnemyRemoveGameobjectFromRadarUseCaseImpl();
    private SpacecraftEnemyGetListGameobjectsInRadarUseCase getListGameobjectsInRadarUseCase = new SpacecraftEnemyGetListGameobjectsInRadarUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private HandlerRadarEnemyViewModelDelegate _myDelegate;
    private RadarEnemy _currentRadar;
    private int _currentRadiusRadar;
    private IdentificatorModel identificatorModel;
    private List<GameObject> _gameobjectsInRadar;

    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerRadarEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public RadarEnemy currentRadar => _currentRadar;

    public int currentRadiusRadar => _currentRadiusRadar;

    public List<GameObject> currentGameobjectInRadar => _gameobjectsInRadar;

    public IdentificatorModel identificator => identificatorModel;

    public void addGameObjectToRadar(GameObject gameObject)
    {
        if (identificatorModel == null) return;
        addGameobjectToRadarUseCase.invoke(identificatorModel, gameObject);
    }

    public void loadSpacecraft(IdentificatorModel identificator)
    {
        identificatorModel = identificator;
        _currentSpacecraft = getCurrentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadCurrentSpacecraft();
        loadRadar();
    }

    public void removeGameObjectFromRadar(GameObject gameObject)
    {
        if (identificatorModel == null) return;
        removeGameobjectFromRadarUseCase.invoke(identificatorModel, gameObject);
    }

    //private methods
    private void loadRadar() {
        if (identificatorModel == null) return;
        if (!loadRadarUseCase.invoke(identificatorModel)) return;
        _currentRadar = currentRadarUseCase.invoke(identificatorModel);
        _currentRadiusRadar = currentRadiusRadarUseCase.invoke(identificatorModel) ;
        _gameobjectsInRadar = getListGameobjectsInRadarUseCase.invoke(identificatorModel);
        _myDelegate.notifyLoadRadar();
    }
}