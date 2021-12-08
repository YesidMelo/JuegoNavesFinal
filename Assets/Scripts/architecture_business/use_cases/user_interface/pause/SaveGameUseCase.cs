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
        return await newGameRepository.saveGame(gameModel: generateGameModelBySave(gameModel: gameModelToSave));
    }

    //private methods
    private GameModel generateGameModelBySave(GameModel gameModel) {
        gameModel.currentRadarPlayer = repoRadar.currentRadarPlayer;
        gameModel.listLasers = repoLaserPlayer.listLasers;
        gameModel.life = repoLifePlayer.life;
        gameModel.maxLife = repoLifePlayer.maxLife;
        gameModel.listMotors = repoMotorPlayer.listMotors;
        gameModel.currentShield = repoShield.currentShield;
        gameModel.currentStorage = repoStorage.currentStorage;
        gameModel.currentStructure = repoStructure.currentStructure;
        return gameModel;
    }

}