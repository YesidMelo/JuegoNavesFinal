using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerSpacecraftPlayerViewModelDelegate {
    void notifiesLoadSpacecraft();
}

public interface HandlerSpacecraftPlayerViewModel {

    HandlerSpacecraftPlayerViewModelDelegate myDelegate { get; set; }
    IEnumerator loadSpacecraft();
}

public class HandlerSpacecraftPlayerViewModelImpl : HandlerSpacecraftPlayerViewModel
{
    private SpacecraftPlayerSpacecraftLoadSpacecraftUseCase spacecraftLoadSpacecraftUseCase = new SpacecraftPlayerSpacecraftLoadSpacecraftUseCaseImpl();
    private HandlerSpacecraftPlayerViewModelDelegate _myDelegate;

    public HandlerSpacecraftPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public IEnumerator loadSpacecraft()
    {
        yield return spacecraftLoadSpacecraftUseCase.invoke();
        if (_myDelegate != null) {
            _myDelegate.notifiesLoadSpacecraft();
        }
    }
}