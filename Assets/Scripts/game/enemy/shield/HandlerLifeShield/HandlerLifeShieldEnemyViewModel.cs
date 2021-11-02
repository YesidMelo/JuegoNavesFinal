using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLifeShieldEnemyViewModelDelegate { }

public interface HandlerLifeShieldEnemyViewModel {
    int currentLife(IdentificatorModel identificator);
    HandlerLifeShieldEnemyViewModelDelegate myDelegate { get; set; }
    void removeLife(DetailLaserPlayer detailLaserPlayer, IdentificatorModel identificator);
}

public class HandlerLifeShieldEnemyViewModelImpl : HandlerLifeShieldEnemyViewModel
{
    private SpacecraftEnemyCurrentLifeUseCase currentLifeUseCase = new SpacecraftEnemyCurrentLifeUseCaseImpl();
    private SpacecraftEnemyQuitLifeUseCase quitLifeUseCase = new SpacecraftEnemyQuitLifeUseCaseImpl();

    private HandlerLifeShieldEnemyViewModelDelegate _myDelegate;


    public HandlerLifeShieldEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public int currentLife(IdentificatorModel identificator) => currentLifeUseCase.invoke(identificator);

    public void removeLife(DetailLaserPlayer detailLaserPlayer, IdentificatorModel identificator)
    {
        quitLifeUseCase.invoke(identificator,(int) detailLaserPlayer.impactDamage);
    }
}