using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGameSavedUseCase {
    public Task invoke(GameModel gameModel);
}

public class LoadGameSavedUseCaseImpl : LoadGameSavedUseCase
{
    private readonly LoadGameRepo loadGameRepo = new LoadGameRepositoryImpl();
    private readonly NewGameRepository newGameRepository = new NewGameRepositoryImpl();
    private readonly SpacecraftPlayerLaserRepository repoLasers = new SpacecraftPlayerLaserRepositoryImpl();
    private readonly SpacecraftPlayerLifeRepository repoLife = new SpacecraftPlayerLifeRepositoryImpl();
    private readonly SpacecraftPlayerMotorRepository repoMotor = new SpacecraftPlayerMotorRepositoryImpl();
    private readonly SpacecraftPlayerRadarRepository repoRadar = new SpacecraftPlayerRadarRepositoryImpl();
    private readonly SpacecraftPlayerShieldRepository repoShield = new SpacecraftPlayerShieldRepositoryImpl();
    private readonly SpacecraftPlayerStorageRepository repoStorage = new SpacecraftPlayerStorageRepositoryImpl();
    private readonly SpacecraftPlayerStructureRepository repoStructure = new SpacecraftPlayerStructureRepositoryImpl();
    private readonly SpacecraftPlayerLifeSupportRepository repoLifeSupport = new SpacecraftPlayerLifeSupportRepositoryImpl();

    public async Task invoke(GameModel gameModel)
    {
        await loadGameRepo.loadGameModel(gameModel: gameModel);
        initLasers(gameModel: gameModel);
        initLife(gameModel: gameModel);
        initLifeSupport(gameModel: gameModel);
        initMotors(gameModel: gameModel);
        initRadar(gameModel: gameModel);
        initShield(gameModel: gameModel);
        initStorage(gameModel: gameModel);
        initStructure(gameModel: gameModel);
        await initNewGame(gameModel: gameModel);
    }

    //private methods
    private void initLasers(GameModel gameModel) => repoLasers.setCurrentLaserModel(laserModel: gameModel.laserModel);

    private void initLife(GameModel gameModel) {
        repoLife.addStructureLife(gameModel.structureModel.currentStructure);
        repoLife.setCurrentLifeModel(lifeModel: gameModel.lifeModel);
    }

    private void initLifeSupport(GameModel gameModel) => repoLifeSupport.setCurrentLifeSupportModel(lifeSupportModel: gameModel.lifeSupportModel);

    private void initMotors(GameModel gameModel) => repoMotor.setCurrentMotorModel(motorModel: gameModel.motorModel);
    private void initRadar(GameModel gameModel) => repoRadar.setCurrentRadarModel(radarModel: gameModel.radarModel);
    private void initShield(GameModel gameModel) => repoShield.setCurrentShield(shieldModel: gameModel.shieldModel);
    private void initStorage(GameModel gameModel) => repoStorage.setCurrentStorageModel(storageModel: gameModel.storageModel);
    private void initStructure(GameModel gameModel) => repoStructure.setCurrentStructureModel(structureModel: gameModel.structureModel);

    private async Task initNewGame(GameModel gameModel) {
        await newGameRepository.setNewGameModel(newGameModel: gameModel);
    }

}