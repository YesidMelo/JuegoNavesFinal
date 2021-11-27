using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLifeShieldPlayerViewModelDelegate { }

public interface HandlerLifeShieldPlayerViewModel {
    void removeLife(Collider2D collision);
    HandlerLifeShieldPlayerViewModelDelegate myDelegate { get; set; }
    StructurePlayer currentStructure { get; }
}

public class HandlerLifeShieldPlayerViewModelImpl : HandlerLifeShieldPlayerViewModel
{
    private SpacecraftPlayerQuitLifeUseCase quitLifeUseCase = new SpacecraftPlayerQuitLifeUseCaseImpl();
    private SpacecraftPlayerGetCurrentStructureUseCase getCurrentStructureUseCase = new SpacecraftPlayerGetCurrentStructureUseCaseImpl();

    private HandlerLifeShieldPlayerViewModelDelegate _myDelegate;

    public HandlerLifeShieldPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public StructurePlayer currentStructure => getCurrentStructureUseCase.invoke();

    public void removeLife(Collider2D collision)
    {
        HandlerAmmounitionLaserEnemy handler = collision.gameObject.GetComponent<HandlerAmmounitionLaserEnemy>();
        if (handler == null) return;
        quitLifeUseCase.invoke(handler.detailLaser.impactDamage);
    }
}