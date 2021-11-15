using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLaserEnemyViewModelDelegate {
    void notifyLoadSpacecraft();
    void notifyLoadLasers();
}
public interface HandlerLaserEnemyViewModel { 

    float impactLaser { get; }
    LaserEnemy currentLaser { get; }
    IdentificatorModel identificator { get; }

    SpacecraftEnemy currentSpacecraft { get; }
    HandlerLaserEnemyViewModelDelegate myDelegate { get; set; }
    void loadCurrentSpacecraft(IdentificatorModel identificator);

    void deleteLaser();
}
public class HandlerLaserEnemyViewModelImpl : HandlerLaserEnemyViewModel
{
    private SpacecraftEnemyGetCurrentSpacecraftUseCase currentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private SpacecraftEnemyLoadLaserUseCase loadLaserUseCase = new SpacecraftEnemyLoadLaserUseCaseImpl();
    private SpacecraftEnemyDeleteLaserUseCase deleteLaserUseCase = new SpacecraftEnemyDeleteLaserUseCaseImpl();
    private SpacecraftEnemyGetImpactLaserUseCase impactLaserUseCase = new SpacecraftEnemyGetImpactLaserUseCaseImpl();
    private SpacecraftEnemyGetTypeLaserUseCase getTypeLaserUseCase = new SpacecraftEnemyGetTypeLaserUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private HandlerLaserEnemyViewModelDelegate _myDelegate;
    private IdentificatorModel identificatorModel;
    private float _impactLaser;
    private LaserEnemy _currentLaser;


    //gets and sets
    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerLaserEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value;
    }

    public float impactLaser => _impactLaser;

    public LaserEnemy currentLaser => _currentLaser;

    public IdentificatorModel identificator => identificatorModel;

    public void deleteLaser()
    {
        if (identificatorModel == null) return;
        deleteLaserUseCase.invoke(identificatorModel);
    }

    public void loadCurrentSpacecraft(IdentificatorModel identificator)
    {
        identificatorModel = identificator;
        _currentSpacecraft = currentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadSpacecraft();
        loadLaser(identificator);
    }

    //private methods
    private void loadLaser(IdentificatorModel identificator) {
        if (!loadLaserUseCase.invoke(identificator)) return;
        _impactLaser = impactLaserUseCase.invoke(identificator);
        _currentLaser = getTypeLaserUseCase.invoke(identificator);
        _myDelegate.notifyLoadLasers();
    }

    


}