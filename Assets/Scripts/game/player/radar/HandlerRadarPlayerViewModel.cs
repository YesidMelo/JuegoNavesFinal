using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerRadarPlayerViewModelDelegate {
    void notifyLoadRadar();
}
public interface HandlerRadarPlayerViewModel {
    List<GameObject> listObjects { get; }
    float currentRadiusRadar { get; }
    RadarPlayer currentRadar { get; }
    void addElementToRadar(GameObject gameObject);
    void clearElementsFromRadar();
    void loadRadar();
    void removeElementFromRadar(GameObject gameObject);
    void updateCurrentRadar(RadarPlayer radarPlayer);
    HandlerRadarPlayerViewModelDelegate myDelegate { get; set; }
}

public class HandlerRadarPlayerViewModelImpl : HandlerRadarPlayerViewModel
{
    private SpacecraftPlayerAddObjectToRadarUseCase addObjectToRadarUseCase = new SpacecraftPlayerAddObjectToRadarUseCaseImpl();
    private SpacecraftPlayerClearObjectFromRadarUseCase clearObjectFromRadarUseCase = new SpacecraftPlayerClearObjectFromRadarUseCaseImpl();
    private SpacecraftPlayerCurrentRadarUseCase currentRadarUseCase = new SpacecraftPlayerCurrentRadarUseCaseImpl();
    private SpacecraftPlayerGetListObjectsFromRadarUseCase getListObjectsFromRadarUseCase = new SpacecraftPlayerGetListObjectsFromRadarUseCaseImpl();
    private SpacecraftPlayerLoadRadarUseCase loadRadarUseCase = new SpacecraftPlayerLoadRadarUseCaseImpl();
    private SpacecraftPlayerRemoveObjectFromRadarUseCase removeObjectFromRadarUseCase = new SpacecraftPlayerRemoveObjectFromRadarUseCaseImpl();
    private SpacecraftPlayerUpdateRadarUseCase updateRadarUseCase = new SpacecraftPlayerUpdateRadarUseCaseImpl();
    private SpacecraftPlayerGetCurrentRadiusRadarUseCase getCurrentRadiusRadarUseCase = new SpacecraftPlayerGetCurrentRadiusRadarUseCaseImpl();

    private HandlerRadarPlayerViewModelDelegate _myDelegate;


    public List<GameObject> listObjects => getListObjectsFromRadarUseCase.invoke();

    public HandlerRadarPlayerViewModelDelegate myDelegate { 
        get => _myDelegate;
        set => _myDelegate = value;
    }

    public float currentRadiusRadar => getCurrentRadiusRadarUseCase.invoke();

    public RadarPlayer currentRadar => currentRadarUseCase.invoke();

    public void addElementToRadar(GameObject gameObject) {
        addObjectToRadarUseCase.invoke(gameObject);
        loadRadar();
    }

    public void clearElementsFromRadar()
    {
        clearObjectFromRadarUseCase.invoke();
        loadRadar();
    }

    public void loadRadar()
    {
        if (!loadRadarUseCase.invoke()) return;
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadRadar();
    }

    public void removeElementFromRadar(GameObject gameObject)
    {
        removeObjectFromRadarUseCase.invoke(gameObject);
        loadRadar();
    }

    public void updateCurrentRadar(RadarPlayer radarPlayer)
    {
        updateRadarUseCase.invoke(radarPlayer);
        loadRadar();
    }
}