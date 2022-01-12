using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerStoragePlayerViewModelDelegate {
    void notifyLoadStorage();
}

public interface HandlerStoragePlayerViewModel { 
    StoragePlayer currentStorage { get; }
    HandlerStoragePlayerViewModelDelegate myDelegate { get; set; }
    void loadStorage();
    void updateStorage(StoragePlayer storage);
    bool isGameInPause();
}

public class HandlerStoragePlayerViewModelImpl : HandlerStoragePlayerViewModel
{
    private SpacecraftPlayerGetCurrentStorageUseCase getCurrentStorageUseCase = new SpacecraftPlayerGetCurrentStorageUseCaseImpl();
    private SpacecraftPlayerLoadStorageUseCase loadStorageUseCase = new SpacecraftPlayerLoadStorageUseCaseImpl();
    private SpacecraftPlayerUpdateStorageUseCase updateStorageUseCase = new SpacecraftPlayerUpdateStorageUseCaseImpl();
    private StatusGameIsGameInPauseUseCase isGameInPauseUseCase = new StatusGameIsGameInPauseUseCaseImpl();

    private HandlerStoragePlayerViewModelDelegate _myDelegate;
    public StoragePlayer currentStorage => getCurrentStorageUseCase.invoke();

    public HandlerStoragePlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public bool isGameInPause() => isGameInPauseUseCase.invoke();

    public void loadStorage()
    {
        if (!loadStorageUseCase.invoke()) return;
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadStorage();
    }

    public void updateStorage(StoragePlayer storage)
    {
        updateStorageUseCase.invoke(storage);
        loadStorage();
    }
}
