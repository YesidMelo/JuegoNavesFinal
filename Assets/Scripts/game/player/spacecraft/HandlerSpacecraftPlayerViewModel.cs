using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerSpacecraftPlayerViewModelDelegate {
    void notifiesLoadSpacecraft();
}

public interface HandlerSpacecraftPlayerViewModel {

    HandlerSpacecraftPlayerViewModelDelegate myDelegate { get; set; }

}

public class HandlerSpacecraftPlayerViewModelImpl : HandlerSpacecraftPlayerViewModel
{
    
    private HandlerSpacecraftPlayerViewModelDelegate _myDelegate;

    public HandlerSpacecraftPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

}