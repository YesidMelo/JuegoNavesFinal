using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperLoadStorageLoadGameDatabase {

    private GameModel gameModel;

    //public methods
    public HelperLoadStorageLoadGameDatabase initValues(GameModel gameModel)
    {
        this.gameModel = gameModel;
        return this;
    }

    public async Task loadStorage()
    {
        try
        {
            List<StorageEntity> storageEntities = await DatabaseManagerImpl.getInstance().getElements<StorageEntity>(conditions: generateListConditionsShield());
            StorageModel storageModel = convertStorageEntityToStorageModel(storageEntities: storageEntities);
            gameModel.storageModel = storageModel;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    //private methods
    private List<Condition> generateListConditionsShield()
    {
        Condition condition = new Condition();
        condition.columnName = "gameModelId";
        condition.value = gameModel.id;
        condition.type = TypeElement.INTEGER;

        List<Condition> listCondition = new List<Condition>();
        listCondition.Add(condition);
        return listCondition;
    }

    private StorageModel convertStorageEntityToStorageModel(List<StorageEntity> storageEntities)
    {
        if (storageEntities.Count == 0) return null;
        StorageEntity storageEntity = storageEntities[0];

        StorageModel storageModel = new StorageModel();
        storageModel.id = storageEntity.id;
        storageModel.gameModelId = storageEntity.gameModelId;
        storageModel.currentStorage = StoragePlayer.TYPE_1.getStoragePlayerByIdDB(storageEntity.typeStorageId);

        return storageModel;
    }

}