using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerShieldPlayerViewModelDelegate {
    void notifyLoadShield();
}

public interface HandlerShieldPlayerViewModel {

    public ShieldPlayer currentShield { get; }
    public void updateShield(ShieldPlayer shield);
    public void loadShield();

    HandlerShieldPlayerViewModelDelegate myDelegate { get; set; }
}

public class HandlerShieldPlayerViewModelImpl : HandlerShieldPlayerViewModel
{
    private SpacecraftPlayerCurrentShieldUseCase currentShieldUseCase = new SpacecraftPlayerCurrentShieldUseCaseImpl();
    private SpacecraftPlayerSetShieldUseCase setShieldUseCase = new SpacecraftPlayerSetShieldUseCaseImpl();
    private SpacecraftPlayerLoadShieldUseCase loadShieldUseCase = new SpacecraftPlayerLoadShieldUseCaseImpl();

    private HandlerShieldPlayerViewModelDelegate _myDelegate;

    public HandlerShieldPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public ShieldPlayer currentShield => currentShieldUseCase.invoke();

    public void loadShield()
    {
        if (!loadShieldUseCase.invoke()) return;
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadShield();
    }

    public void updateShield(ShieldPlayer shield) => setShieldUseCase.invoke(shield);
}