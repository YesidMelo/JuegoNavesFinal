using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLifeShieldPlayerViewModelDelegate { }

public interface HandlerLifeShieldPlayerViewModel {
    void removeLife(Collider2D collision);
    HandlerLifeShieldPlayerViewModelDelegate myDelegate { get; set; }
    StructurePlayer currentStructure { get; }
    void checkIfPlayerIsUnderAttack();
    
    bool playerIsUnderAttack { get; }
}

public class HandlerLifeShieldPlayerViewModelImpl : HandlerLifeShieldPlayerViewModel
{
    private readonly SpacecraftPlayerQuitLifeUseCase quitLifeUseCase = new SpacecraftPlayerQuitLifeUseCaseImpl();
    private readonly SpacecraftPlayerGetCurrentStructureUseCase getCurrentStructureUseCase = new SpacecraftPlayerGetCurrentStructureUseCaseImpl();
    private readonly SpaceCraftPlayerLifeSupportUpdatePlayerIsUnderAttackUseCase updatePlayerIsUnderAttackUseCase = new SpaceCraftPlayerLifeSupportUpdatePlayerIsUnderAttackUseCaseImpl();
    private readonly SpacecraftPlayerLifeSupportPlayerIsUnderAttackUseCase playerIsUnderAttackUseCase = new SpacecraftPlayerLifeSupportPlayerIsUnderAttackUseCaseImpl();
    private readonly SpacecraftPlayerLifeIsMaxLifeUseCase lifeIsMaxLifeUseCase = new SpacecraftPlayerLifeIsMaxLifeUseCaseImpl();
    private readonly LifeSupportPlayerGetCurrentTypeUseCase getCurrentTypeUseCase = new LifeSupportPlayerGetCurrentTypeUseCaseImpl();

    private HandlerLifeShieldPlayerViewModelDelegate _myDelegate;
    private DateTime _nextUpdate;
    private bool _playerIsUnderAttack;

    public HandlerLifeShieldPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public StructurePlayer currentStructure => getCurrentStructureUseCase.invoke();

    public bool playerIsUnderAttack => _playerIsUnderAttack;

    public void checkIfPlayerIsUnderAttack()
    {
        _playerIsUnderAttack = playerIsUnderAttackUseCase.invoke();
        if (lifeIsMaxLifeUseCase.invoke()) return;
        DateTime now = DateTime.Now;
        if (!nowIsMajorOrEqualsNextUpdate(now: now)) return;
        updatePlayerIsUnderAttackUseCase.invoke(false);
    }

    public void removeLife(Collider2D collision)
    {
        HandlerAmmounitionLaserEnemy handler = collision.gameObject.GetComponent<HandlerAmmounitionLaserEnemy>();
        if (handler == null) return;
        quitLifeUseCase.invoke(handler.detailLaser.impactDamage);
        _nextUpdate = DateTime.Now.AddMilliseconds(getCurrentTypeUseCase.invoke().getSpeedEnableReparation());
        updatePlayerIsUnderAttackUseCase.invoke(playerIsUnderAttack: true);
    }

    //private methods
    private bool nowIsMajorOrEqualsNextUpdate(DateTime now)
    {
        return DateTime.Compare(now, _nextUpdate) == 1;
    }
}