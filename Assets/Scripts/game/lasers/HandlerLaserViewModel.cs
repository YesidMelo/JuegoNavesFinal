using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLaserViewModel
{
    int mediaImpactLaser { get; }
    List<Laser> listLasers { get; }
    Laser finalLaser { get; }
    void setListLasers(List<Laser> listLasers);
    void deleteLasers();

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

    public void deleteLasers() {}

    public void setListLasers(List<Laser> listLasers) => spacecraftPlayerSetListLasers.invoke(listLasers);
}

public class HandlerLaserEnemyViewModelImpl : HandlerLaserViewModel {

    private IdentificatorModel _identificator = new IdentificatorModel();

    private SpacecraftEnemyAddLasersUseCase addLasersUseCase = new SpacecraftEnemyAddLasersUseCaseImpl();
    private SpacecraftEnemyDeleteLasersUseCase deleteLasersUseCase = new SpacecraftEnemyDeleteLasersUseCaseImpl();
    private SpacecraftEnemyGetListLasersUseCase getListLasersUseCase = new SpacecraftEnemyGetListLasersUseCaseImpl();
    private SpacecraftEnemyGetMediaImpactLaserUseCase getMediaImpactUseCase = new SpacecraftEnemyGetMediaImpactLaserUseCaseImpl();
    private SpacecraftEnemyGetFinalImpactLaserUseCase finalImpactUseCase = new SpacecraftEnemyGetFinalImpactLaserUseCaseImpl();

    public int mediaImpactLaser => getMediaImpactUseCase.invoke(_identificator);

    public List<Laser> listLasers => getListLasersUseCase.invoke(_identificator);

    public Laser finalLaser => finalImpactUseCase.invoke(_identificator);

    public void deleteLasers() => deleteLasersUseCase.invoke(_identificator);

    public void setListLasers(List<Laser> listLasers) => addLasersUseCase.invoke(listLasers, _identificator);
}