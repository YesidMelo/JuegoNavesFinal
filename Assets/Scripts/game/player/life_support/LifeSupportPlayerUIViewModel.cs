using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LifeSupportPlayerUIViewModelDelegate { }

public interface LifeSupportPlayerUIViewModel {
    LifeSupportPlayerUIViewModelDelegate myDelegate { set; get; }
    LifeSupportPlayer getCurrentLifeSupport { get; }

    bool playerIsUnderAttack { get; }
    bool lifeIsMaxLife { get; }
    void restoreLife();
}

public class LifeSupportPlayerUIViewModelImpl : LifeSupportPlayerUIViewModel
{
    private readonly LifeSupportPlayerGetCurrentTypeUseCase getCurrentTypeUseCase = new LifeSupportPlayerGetCurrentTypeUseCaseImpl();
    private readonly SpacecraftPlayerLifeSupportPlayerIsUnderAttackUseCase playerIsUnderAttackUseCase = new SpacecraftPlayerLifeSupportPlayerIsUnderAttackUseCaseImpl();
    private readonly SpacecraftPlayerLifeIsMaxLifeUseCase lifeIsMaxLifeUseCase = new SpacecraftPlayerLifeIsMaxLifeUseCaseImpl();
    private readonly SpacecraftPlayerAddLifeUseCase addLifeUseCase = new SpacecraftPlayerAddLifeUseCaseImpl();


    private LifeSupportPlayerUIViewModelDelegate _myDelegate;
    private DateTime _nextUpdate;

    public LifeSupportPlayerUIViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public LifeSupportPlayer getCurrentLifeSupport => getCurrentTypeUseCase.invoke();

    public bool playerIsUnderAttack => playerIsUnderAttackUseCase.invoke();

    public bool lifeIsMaxLife => lifeIsMaxLifeUseCase.invoke();


    public void restoreLife()
    {
        if (lifeIsMaxLife) return;
        if (playerIsUnderAttack) return;
        DateTime now = DateTime.Now;
        if (!nowIsMajorOrEqualsNextUpdate(now: now)) return;
        _nextUpdate = now.AddMilliseconds(getCurrentLifeSupport.getSpeedReparation());
        addLifeUseCase.invoke();
    }

    //private methods 

    //Method that checks if now is minor or equals to _nextUpdate datetime
    private bool nowIsMajorOrEqualsNextUpdate(DateTime now) {
        return DateTime.Compare(now, _nextUpdate) == 1;
    }

}