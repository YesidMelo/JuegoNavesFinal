using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperLoadStructureLoadGameDatabase {

    private GameModel gameModel;

    //public methods
    public HelperLoadStructureLoadGameDatabase initValues(GameModel gameModel)
    {
        this.gameModel = gameModel;
        return this;
    }

    public async Task loadStructure()
    {
        try
        {
            List<StructureEntity> storageEntities = await DatabaseManagerImpl.getInstance().getElements<StructureEntity>(conditions: generateListConditionsShield());
            StructureModel structureModel = convertStorageEntityToStorageModel(structureEntities: storageEntities);
            gameModel.structureModel = structureModel;
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

    private StructureModel convertStorageEntityToStorageModel(List<StructureEntity> structureEntities)
    {
        if (structureEntities.Count == 0) return null;
        StructureEntity storageEntity = structureEntities[0];

        StructureModel structureModel = new StructureModel();
        structureModel.id = storageEntity.id;
        structureModel.gameModelId = storageEntity.gameModelId;
        structureModel.currentStructure = StructurePlayer.TYPE_1.getStructurePlayerByIdDB(storageEntity.typeStructureId);

        return structureModel;
    }

}