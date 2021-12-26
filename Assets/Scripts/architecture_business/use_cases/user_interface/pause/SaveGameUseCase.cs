using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface SaveGameUseCase {
    Task<bool> invoke();
}

public class SaveGameUseCaseImpl : SaveGameUseCase
{
    private NewGameRepository newGameRepository = new NewGameRepositoryImpl();
    private SpacecraftPlayerLaserRepository repoLaserPlayer = new SpacecraftPlayerLaserRepositoryImpl();
    private SpacecraftPlayerLifeRepository repoLifePlayer = new SpacecraftPlayerLifeRepositoryImpl();
    private SpacecraftPlayerMotorRepository repoMotorPlayer = new SpacecraftPlayerMotorRepositoryImpl();
    private SpacecraftPlayerRadarRepository repoRadar = new SpacecraftPlayerRadarRepositoryImpl();
    private SpacecraftPlayerShieldRepository repoShield = new SpacecraftPlayerShieldRepositoryImpl();
    private SpacecraftPlayerStorageRepository repoStorage = new SpacecraftPlayerStorageRepositoryImpl();
    private SpacecraftPlayerStructureRepository repoStructure = new SpacecraftPlayerStructureRepositoryImpl();

    public async Task<bool> invoke() {
        GameModel gameModelToSave = await newGameRepository.getCurrentNewGameModel();
        GameModel gameModelFinalToSave =  generateGameModelBySave(gameModel: gameModelToSave);
        if (gameModelFinalToSave == null) return false;
        return await newGameRepository.saveGame(gameModel: gameModelFinalToSave);
    }

    //private methods
    private GameModel generateGameModelBySave(GameModel gameModel) {
        try {
            gameModel.radarModel = repoRadar.currentRadarModel;
            gameModel.laserModel = repoLaserPlayer.currentLaserModel;
            gameModel.lifeModel = repoLifePlayer.currentLifeModel;
            gameModel.motorModel = repoMotorPlayer.currentMotorModel;
            gameModel.shieldModel = repoShield.currentShieldModel;
            gameModel.storageModel = repoStorage.currentStorageModel;
            gameModel.structureModel = repoStructure.currentStructureModel;
            return gameModel;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return null;
        }
    }

}