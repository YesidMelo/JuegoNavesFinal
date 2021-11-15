using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLaserPlayerViewModelDelegate {
    void lasersLoaded();
}

public interface HandlerLaserPlayerViewModel {
    bool shooting { get; }
    float impactDamage { get; }
    LaserPlayer typeLaser{ get; }
    List<LaserPlayer> listLaser{ get; }
    HandlerLaserPlayerViewModelDelegate myDelegate { get; set; }
    Action currentAction { get; }

    bool loadLasers();
    void calculateLasers(List<LaserPlayer> listLasers);

    
}

public class HandlerLaserPlayerViewModelImpl : HandlerLaserPlayerViewModel
{
    private SpacecraftPlayerGetFinalLaserUseCase finalLaserUseCase = new SpacecraftPlayerGetFinalLaserUseCaseImpl();
    private SpacecraftPlayerGetListLasersUseCase listLasersUseCase = new SpacecraftPlayerGetListLasersUseCaseImpl();
    private SpacecraftPlayerMediaImpactLaserUseCase mediaImpactLaserUseCase = new SpacecraftPlayerMediaImpactLaserUseCaseImpl();
    private SpacecraftPlayerSetListLasersUseCase setListLasersUseCase = new SpacecraftPlayerSetListLasersUseCaseImpl();
    private SpacecraftPlayerLoadLasersUseCase loadLasersUseCase = new SpacecraftPlayerLoadLasersUseCaseImpl();
    private CurrentActionSpacecraftUseCase currentActionSpacecraftUseCase = new CurrentActionSpacecraftUseCaseImpl();
    private SpacecraftPlayerGetCurrentEnemyUseCase getCurrentEnemyUseCase = new SpacecraftPlayerGetCurrentEnemyUseCaseImpl();
    private HandlerLaserPlayerViewModelDelegate _myDelegate;

    public float impactDamage => mediaImpactLaserUseCase.invoke();

    public LaserPlayer typeLaser => finalLaserUseCase.invoke();

    public List<LaserPlayer> listLaser => listLasersUseCase.invoke();

    public HandlerLaserPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public Action currentAction => currentActionSpacecraftUseCase.invoke();

    public bool shooting {
        get {
            if (currentAction == Action.ATTACK && getCurrentEnemyUseCase.invoke() != null) {
                return true;
            }
            return false;
        }
    }

    public void calculateLasers(List<LaserPlayer> listLasers) => setListLasersUseCase.invoke(listLaser);

    public bool loadLasers() {
        if (!loadLasersUseCase.invoke()) return false;
        if (_myDelegate == null) return true;
        _myDelegate.lasersLoaded();
        return true;
    }
}


