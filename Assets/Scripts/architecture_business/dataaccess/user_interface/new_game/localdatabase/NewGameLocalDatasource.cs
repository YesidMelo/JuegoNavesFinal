using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameLocalDatasource {
    Task<bool> saveGame(GameModel gameModel);
}

public class NewGameLocalDatasourceImpl : NewGameLocalDatasource
{

    private readonly HelperNewGameLocalDatasource helperNewGameLocalDatasource = new HelperNewGameLocalDatasource();
    private readonly HelperSaveLaserNewGameLocalDatasource helperSaveLaserNewGame = new HelperSaveLaserNewGameLocalDatasource();
    private readonly HelperSaveLifeNewGameLocalDatasource helperSaveLifeNewGameLocalDatasource = new HelperSaveLifeNewGameLocalDatasource();
    private readonly HelperSaveMotorNewGameLocalDatasource helperSaveMotorNewGameLocalDatasource = new HelperSaveMotorNewGameLocalDatasource();
    private readonly HelperSaveRadarNewGameLocalDatasource helperSaveRadarNewGameLocalDatasource = new HelperSaveRadarNewGameLocalDatasource();
    private readonly HelperSaveShieldNewGameLocalDatasource helperSaveShieldNewGameLocalDatasource = new HelperSaveShieldNewGameLocalDatasource();
    private readonly HelperSaveStorageNewGameLocalDatasource helperSaveStorageNewGameLocalDatasource = new HelperSaveStorageNewGameLocalDatasource();
    private readonly HelperSaveStructureNewGameLocalDatasource helperSaveStructureNewGameLocalDatasource = new HelperSaveStructureNewGameLocalDatasource();
    private readonly HelperSaveLifeSupportNewGameLocalDatasource helperSaveLifeSupportNewGameLocalDatasource = new HelperSaveLifeSupportNewGameLocalDatasource();
    
    public async Task<bool> saveGame(GameModel gameModel)
    {
        try {
            long idGame = await helperNewGameLocalDatasource.saveGameEntity(gameModel: gameModel);
            await helperSaveLaserNewGame.initValues(laserModel: gameModel.laserModel, idGameModel: idGame).saveLaserModel();
            await helperSaveLifeNewGameLocalDatasource.initValues(lifeModel: gameModel.lifeModel, idGameModel: idGame).saveLife();
            await helperSaveLifeSupportNewGameLocalDatasource.initValues(lifeSupportModel: gameModel.lifeSupportModel, idGameModel: idGame).saveLifeSupport();
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