using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGameSavedUseCase {
    public Task invoke(GameModel gameModel);
}

public class LoadGameSavedUseCaseImpl : LoadGameSavedUseCase
{
    private LoadGameRepo loadGameRepo = new LoadGameRepositoryImpl();
    private SpacecraftPlayerLaserRepository repoLasers = new SpacecraftPlayerLaserRepositoryImpl();
    private SpacecraftPlayerLifeRepository repoLife = new SpacecraftPlayerLifeRepositoryImpl();
    private SpacecraftPlayerMotorRepository repoMotor = new SpacecraftPlayerMotorRepositoryImpl();
    private SpacecraftPlayerRadarRepository repoRadar = new SpacecraftPlayerRadarRepositoryImpl();
    private SpacecraftPlayerShieldRepository repoShield = new SpacecraftPlayerShieldRepositoryImpl();
    private SpacecraftPlayerStorageRepository repoStorage = new SpacecraftPlayerStorageRepositoryImpl();
    private SpacecraftPlayerStructureRepository repoStructure = new SpacecraftPlayerStructureRepositoryImpl();

    public async Task invoke(GameModel gameModel)
    {
        await loadGameRepo.loadGameModel(gameModel: gameModel);
        initLasers(gameModel: gameModel);
        initLife(gameModel: gameModel);
        initMotors(gameModel: gameModel);
        initRadar(gameModel: gameModel);
        initShield(gameModel: gameModel);
        initStorage(gameModel: gameModel);
        initStructure(gameModel: gameModel);
    }

    //private methods
    private void initLasers(GameModel gameModel) => repoLasers.setCurrentLaserModel(laserModel: gameModel.laserModel);

    private void initLife(GameModel gameModel) {
        repoLife.addStructureLife(gameModel.structureModel.currentStructure);
        repoLife.setCurrentLifeModel(lifeModel: gameModel.lifeModel);
    }

    private void initMotors(GameModel gameModel) => repoMotor.setCurrentMotorModel(motorModel: gameModel.motorModel);
    private void initRadar(GameModel gameModel) => repoRadar.setCurrentRadarModel(radarModel: gameModel.radarModel);
    private void initShield(GameModel gameModel) => repoShield.setCurrentShield(shieldModel: gameModel.shieldModel);
    private void initStorage(GameModel gameModel) => repoStorage.setCurrentStorageModel(storageModel: gameModel.storageModel);
    private void initStructure(GameModel gameModel) => repoStructure.setCurrentStructureModel(structureModel: gameModel.structureModel);

}