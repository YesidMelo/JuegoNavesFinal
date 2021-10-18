using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLaserEnemyViewModelDelegate {
    void notifyLoadLasers();
}
public interface HandlerLaserEnemyViewModel {

    List<LaserEnemy> listLasers { get; }
    LaserEnemy impactLaser { get; }
    int mediaImpactLaser { get; }
    HandlerLaserEnemyViewModelDelegate myDelegate { get; set; }
    bool loadListLasers(IdentificatorModel identificatorModel);
    void addListLasers(IdentificatorModel identificatorModel, List<LaserEnemy> listLasers);
    void deleteLasers(IdentificatorModel identificatorModel);
    
}
public class HandlerLaserEnemyViewModelImpl : HandlerLaserEnemyViewModel
{
    private SpacecraftEnemyAddLasersUseCase addLasersUseCase = new SpacecraftEnemyAddLasersUseCaseImpl();
    private SpacecraftEnemyDeleteLasersUseCase deleteLasersUseCase = new SpacecraftEnemyDeleteLasersUseCaseImpl();
    private SpacecraftEnemyGetFinalImpactLaserUseCase finalImpactLaserUseCase = new SpacecraftEnemyGetFinalImpactLaserUseCaseImpl();
    private SpacecraftEnemyGetListLasersUseCase getListLasersUseCase = new SpacecraftEnemyGetListLasersUseCaseImpl();
    private SpacecraftEnemyGetMediaImpactLaserUseCase getMediaImpactLaserUseCase = new SpacecraftEnemyGetMediaImpactLaserUseCaseImpl();
    private SpacecraftEnemyLoadLasersUseCase loadLasersUseCase = new SpacecraftEnemyLoadLasersUseCaseImpl();

    private HandlerLaserEnemyViewModelDelegate _myDelegate;
    private List<LaserEnemy> _listLasers = new List<LaserEnemy>();
    private int _mediaImpactLaser = 1;
    private LaserEnemy _impactLaser = LaserEnemy.TYPE_1;

    public HandlerLaserEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public List<LaserEnemy> listLasers => _listLasers;

    public LaserEnemy impactLaser => _impactLaser;

    public int mediaImpactLaser => _mediaImpactLaser;

    public void addListLasers(IdentificatorModel identificatorModel, List<LaserEnemy> listLasers) { 
        addLasersUseCase.invoke(listLasers, identificatorModel);
        loadListLasers(identificatorModel);
    }

    public void deleteLasers(IdentificatorModel identificatorModel) => deleteLasersUseCase.invoke(identificatorModel);

    public bool loadListLasers(IdentificatorModel identificatorModel)
    {
        if (!loadLasersUseCase.invoke(identificatorModel)) return false;
        _impactLaser = finalImpactLaserUseCase.invoke(identificatorModel);
        _listLasers = getListLasersUseCase.invoke(identificatorModel);
        _mediaImpactLaser = getMediaImpactLaserUseCase.invoke(identificatorModel);
        if (_myDelegate == null) return true;
        _myDelegate.notifyLoadLasers();
        return true;
    }
}