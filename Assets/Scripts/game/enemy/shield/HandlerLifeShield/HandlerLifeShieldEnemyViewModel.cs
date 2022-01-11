using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLifeShieldEnemyViewModelDelegate { }

public interface HandlerLifeShieldEnemyViewModel {
    float currentLife(IdentificatorModel identificator);
    SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator);
    HandlerLifeShieldEnemyViewModelDelegate myDelegate { get; set; }
    void removeLife(DetailLaserPlayer detailLaserPlayer, IdentificatorModel identificator);
}

public class HandlerLifeShieldEnemyViewModelImpl : HandlerLifeShieldEnemyViewModel
{
    private SpacecraftEnemyCurrentLifeUseCase currentLifeUseCase = new SpacecraftEnemyCurrentLifeUseCaseImpl();
    private SpacecraftEnemyQuitLifeUseCase quitLifeUseCase = new SpacecraftEnemyQuitLifeUseCaseImpl();
    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();

    private HandlerLifeShieldEnemyViewModelDelegate _myDelegate;


    public HandlerLifeShieldEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public float currentLife(IdentificatorModel identificator) => currentLifeUseCase.invoke(identificator);

    public SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator) => getCurrentSpacecraftUseCase.invoke(identificator);

    public void removeLife(DetailLaserPlayer detailLaserPlayer, IdentificatorModel identificator)
    {
        quitLifeUseCase.invoke(identificator,(int) detailLaserPlayer.impactDamage);
    }
}