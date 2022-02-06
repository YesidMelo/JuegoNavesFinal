using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface DeleteGameDatabaseDataSource {
    Task<bool> deleteAllGames();
    Task<bool> deleteGame(GameModel gameModel);
}

public class DeleteGameDatabaseDataSourceImpl : DeleteGameDatabaseDataSource
{
    public async Task<bool> deleteAllGames()
    {
        return true;
    }

    public async Task<bool> deleteGame(GameModel gameModel)
    {
        if (gameModel.id == null) return false;
        try
        {
            await DatabaseManagerImpl.getInstance().deleteElementsWithCondition<LifeEntity>(conditions: getListConditionPartsSpacecraft(gameId: (long)gameModel.id));
            await DatabaseManagerImpl.getInstance().deleteElementsWithCondition<LaserEntity>(conditions: getListConditionPartsSpacecraft(gameId: (long)gameModel.id));
            await DatabaseManagerImpl.getInstance().deleteElementsWithCondition<MotorEntity>(conditions: getListConditionPartsSpacecraft(gameId: (long)gameModel.id));
            await DatabaseManagerImpl.getInstance().deleteElementsWithCondition<RadarEntitty>(conditions: getListConditionPartsSpacecraft(gameId: (long)gameModel.id));
            await DatabaseManagerImpl.getInstance().deleteElementsWithCondition<ShieldEntity>(conditions: getListConditionPartsSpacecraft(gameId: (long)gameModel.id));
            await DatabaseManagerImpl.getInstance().deleteElementsWithCondition<StorageEntity>(conditions: getListConditionPartsSpacecraft(gameId: (long)gameModel.id));
            await DatabaseManagerImpl.getInstance().deleteElementsWithCondition<StructureEntity>(conditions: getListConditionPartsSpacecraft(gameId: (long)gameModel.id));
            await DatabaseManagerImpl.getInstance().deleteElementsWithCondition<GameEntity>(conditions: getListConditionGame(gameId: (long)gameModel.id));
            
            return true;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }

    //private methods
    private List<Condition> getListConditionPartsSpacecraft(long gameId) {
        Condition condition = new Condition();
        condition.columnName = "gameModelId";
        condition.type = TypeElement.INTEGER;
        condition.value = gameId;

        List<Condition> conditions = new List<Condition>();
        conditions.Add(condition);
        return conditions;
    }
    
    private List<Condition> getListConditionGame(long gameId) {
        Condition condition = new Condition();
        condition.columnName = "id";
        condition.type = TypeElement.INTEGER;
        condition.value = gameId;

        List<Condition> conditions = new List<Condition>();
        conditions.Add(condition);
        return conditions;
    }
}