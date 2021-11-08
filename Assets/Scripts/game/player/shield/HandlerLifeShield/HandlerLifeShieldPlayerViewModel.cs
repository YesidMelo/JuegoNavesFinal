using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLifeShieldPlayerViewModelDelegate { }

public interface HandlerLifeShieldPlayerViewModel {
    void removeLife(Collider2D collision);
    HandlerLifeShieldPlayerViewModelDelegate myDelegate { get; set; }
}

public class HandlerLifeShieldPlayerViewModelImpl : HandlerLifeShieldPlayerViewModel
{
    private SpacecraftPlayerQuitLifeUseCase quitLifeUseCase = new SpacecraftPlayerQuitLifeUseCaseImpl();

    private HandlerLifeShieldPlayerViewModelDelegate _myDelegate;

    public HandlerLifeShieldPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public void removeLife(Collider2D collision)
    {
        HandlerAmmounitionLaserEnemy handler = collision.gameObject.GetComponent<HandlerAmmounitionLaserEnemy>();
        if (handler == null) return;
        quitLifeUseCase.invoke(handler.detailLaser.impactDamage);
    }
}