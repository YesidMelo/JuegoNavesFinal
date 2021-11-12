using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerCameraPlayerViewModelDelegate { }
public interface HandlerCameraPlayerViewModel {
    HandlerCameraPlayerViewModelDelegate myDelegate { get; set; }
}
public class HandlerCameraPlayerViewModelImpl : HandlerCameraPlayerViewModel
{
    private HandlerCameraPlayerViewModelDelegate _myDelegate;

    public HandlerCameraPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate =value;
    }

}