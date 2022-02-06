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
    private readonly NewGameRepository newGameRepository = new NewGameRepositoryImpl();
    private readonly SpacecraftPlayerLaserRepository repoLaserPlayer = new SpacecraftPlayerLaserRepositoryImpl();
    private readonly SpacecraftPlayerLifeRepository repoLifePlayer = new SpacecraftPlayerLifeRepositoryImpl();
    private readonly SpacecraftPlayerMotorRepository repoMotorPlayer = new SpacecraftPlayerMotorRepositoryImpl();
    private readonly SpacecraftPlayerRadarRepository repoRadar = new SpacecraftPlayerRadarRepositoryImpl();
    private readonly SpacecraftPlayerShieldRepository repoShield = new SpacecraftPlayerShieldRepositoryImpl();
    private readonly SpacecraftPlayerStorageRepository repoStorage = new SpacecraftPlayerStorageRepositoryImpl();
    private readonly SpacecraftPlayerStructureRepository repoStructure = new SpacecraftPlayerStructureRepositoryImpl();
    private readonly SpacecraftPlayerLifeSupportRepository repoLifeSupport = new SpacecraftPlayerLifeSupportRepositoryImpl();

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
            gameModel.lifeSupportModel = repoLifeSupport.currentLifeSupportModel;
            return gameModel;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return null;
        }
    }

}