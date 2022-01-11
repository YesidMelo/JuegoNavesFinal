using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameLocalDatasource {
    Task<bool> saveGame(GameModel gameModel);
    Task<bool> loadGame();
    Task<bool> loadListGamesAvailables();
}

public class NewGameLocalDatasourceImpl : NewGameLocalDatasource
{

    private HelperNewGameLocalDatasource helperNewGameLocalDatasource = new HelperNewGameLocalDatasource();
    private HelperSaveLaserNewGameLocalDatasource helperSaveLaserNewGame = new HelperSaveLaserNewGameLocalDatasource();
    private HelperSaveLifeNewGameLocalDatasource helperSaveLifeNewGameLocalDatasource = new HelperSaveLifeNewGameLocalDatasource();
    private HelperSaveMotorNewGameLocalDatasource helperSaveMotorNewGameLocalDatasource = new HelperSaveMotorNewGameLocalDatasource();
    private HelperSaveRadarNewGameLocalDatasource helperSaveRadarNewGameLocalDatasource = new HelperSaveRadarNewGameLocalDatasource();
    private HelperSaveShieldNewGameLocalDatasource helperSaveShieldNewGameLocalDatasource = new HelperSaveShieldNewGameLocalDatasource();
    private HelperSaveStorageNewGameLocalDatasource helperSaveStorageNewGameLocalDatasource = new HelperSaveStorageNewGameLocalDatasource();
    private HelperSaveStructureNewGameLocalDatasource helperSaveStructureNewGameLocalDatasource = new HelperSaveStructureNewGameLocalDatasource();
    public async Task<bool> loadGame()
    {
        await Task.Delay(1000);
        return true;
    }

    public async Task<bool> loadListGamesAvailables()
    {
        await Task.Delay(1000);
        return true;
    }

    public async Task<bool> saveGame(GameModel gameModel)
    {
        try {
            long idGame = await helperNewGameLocalDatasource.saveGameEntity(gameModel: gameModel);
            await helperSaveLaserNewGame.initValues(laserModel: gameModel.laserModel, idGameModel: idGame).saveLaserModel();
            await helperSaveLifeNewGameLocalDatasource.initValues(lifeModel: gameModel.lifeModel, idGameModel: idGame).saveLife();
            await helperSaveMotorNewGameLocalDatasource.initValues(motorModel: gameModel.motorModel, idGameModel: idGame).saveMotors();
            await helperSaveRadarNewGameLocalDatasource.initValues(radarModel: gameModel.radarModel, idGameModel: idGame).saveRadar();
            await helperSaveShieldNewGameLocalDatasource.initValues(shieldModel: gameModel.shieldModel, idGameModel: idGame).saveShield();
            await helperSaveStorageNewGameLocalDatasource.initValues(storageModel: gameModel.storageModel, idGameModel: idGame).saveStorage();
            await helperSaveStructureNewGameLocalDatasource.initValues(structureModel: gameModel.structureModel, idGameModel: idGame).saveStructure();

            Debug.Log($"id game to save = {idGame}");
            return true;
        } catch (Exception e) {
            Debug.Log(e.Message);
            return true;
        }
    }

}