using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLaserViewModel
{
    int mediaImpactLaser { get; }
    List<Laser> listLasers { get; }
    Laser finalLaser { get; }
    void setListLasers(List<Laser> listLasers);

}

public class HandlerLaserPlayerViewModelImpl : HandlerLaserViewModel
{
    private SpacecraftPlayerSetListLasersUseCase spacecraftPlayerSetListLasers = new SpacecraftPlayerSetListLasersUseCaseImpl();
    private SpacecraftPlayerMediaImpactLaserUseCase spacecraftPlayerMediaImpactLaser = new SpacecraftPlayerMediaImpactLaserUseCaseImpl();
    private SpacecraftPlayerGetListLasersUseCase spacecraftPlayerGetListLasers = new SpacecraftPlayerGetListLasersUseCaseImpl();
    private SpacecraftPlayerGetFinalLaserUseCase spacecraftPlayerGetFinalLaser = new SpacecraftPlayerGetFinalLaserUseCaseImpl();

    public int mediaImpactLaser => spacecraftPlayerMediaImpactLaser.invoke();

    public List<Laser> listLasers => spacecraftPlayerGetListLasers.invoke();

    public Laser finalLaser => spacecraftPlayerGetFinalLaser.invoke();

    public void setListLasers(List<Laser> listLasers) => spacecraftPlayerSetListLasers.invoke(listLasers);
}

public class HandlerLaserEnemyViewModelImpl : HandlerLaserViewModel {

    List<Laser> _listLasers = new List<Laser>();
    public HandlerLaserEnemyViewModelImpl() { 
    }

    public int mediaImpactLaser => 1;

    public List<Laser> listLasers => _listLasers;

    public Laser finalLaser => Laser.TYPE_1;

    public void setListLasers(List<Laser> listLasers) => this._listLasers = listLasers;
}