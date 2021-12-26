using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperNewGameLocalDatasource {

    private DatabaseManager databaseManager = DatabaseManagerImpl.getInstance();

    public async Task<long>  saveGameEntity(GameModel gameModel) {
        await getCurrentIndexBySaveGame(gameModel: gameModel);
        GameEntity gameEntity = (new ChangeBetweenObject<GameModel, GameEntity>()).transform(gameModel);
        await databaseManager.insert(gameEntity);
        return (long)gameEntity.id;
    }

    //private methods
    private async Task getCurrentIndexBySaveGame(GameModel gameModel) {
        try
        {
            if (gameModel.id != null && gameModel.id != 0) return;
            long currentLastIndex = await databaseManager.getLastIndex<GameEntity>();
            gameModel.id = currentLastIndex + 1;
        }
        catch (Exception e) {
            Debug.Log(e.Message);
        }
    }

}