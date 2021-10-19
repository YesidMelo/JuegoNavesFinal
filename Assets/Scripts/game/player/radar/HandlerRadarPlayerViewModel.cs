using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerRadarPlayerViewModelDelegate {
    void notifyLoadRadar();
}
public interface HandlerRadarPlayerViewModel {
    List<GameObject> listObjects { get; }
    void addElementToRadar(GameObject gameObject);
    void clearElementsFromRadar();
    void loadRadar();
    void removeElementFromRadar(GameObject gameObject);
    HandlerRadarPlayerViewModelDelegate myDelegate { get; set; }
}

public class HandlerRadarPlayerViewModelImpl : HandlerRadarPlayerViewModel
{
    private SpacecraftPlayerAddObjectToRadarUseCase addObjectToRadarUseCase = new SpacecraftPlayerAddObjectToRadarUseCaseImpl();
    private SpacecraftPlayerClearObjectFromRadarUseCase clearObjectFromRadarUseCase = new SpacecraftPlayerClearObjectFromRadarUseCaseImpl();
    private SpacecraftPlayerGetListObjectsFromRadarUseCase getListObjectsFromRadarUseCase = new SpacecraftPlayerGetListObjectsFromRadarUseCaseImpl();
    private SpacecraftPlayerLoadRadarUseCase loadRadarUseCase = new SpacecraftPlayerLoadRadarUseCaseImpl();
    private SpacecraftPlayerRemoveObjectFromRadarUseCase removeObjectFromRadarUseCase = new SpacecraftPlayerRemoveObjectFromRadarUseCaseImpl();
    private HandlerRadarPlayerViewModelDelegate _myDelegate;


    public List<GameObject> listObjects => getListObjectsFromRadarUseCase.invoke();

    public HandlerRadarPlayerViewModelDelegate myDelegate { 
        get => _myDelegate;
        set => _myDelegate = value;
    }

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
}