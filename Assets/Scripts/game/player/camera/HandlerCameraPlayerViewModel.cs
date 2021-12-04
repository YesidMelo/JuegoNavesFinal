using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerCameraPlayerViewModelDelegate { }
public interface HandlerCameraPlayerViewModel {
    HandlerCameraPlayerViewModelDelegate myDelegate { get; set; }
    GameObject currentPlayer { get; }
}
public class HandlerCameraPlayerViewModelImpl : HandlerCameraPlayerViewModel
{
    private HandlerCameraPlayerViewModelDelegate _myDelegate;
    private GetCurrentPlayerUseCase getCurrentPlayerUseCase = new GetCurrentPlayerUseCaseImpl();

    

    public HandlerCameraPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate =value;
    }

    public GameObject currentPlayer => getCurrentPlayerUseCase.invoke();
}