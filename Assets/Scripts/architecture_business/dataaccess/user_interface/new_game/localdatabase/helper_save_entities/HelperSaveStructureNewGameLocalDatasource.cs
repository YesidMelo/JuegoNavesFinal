using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperSaveStructureNewGameLocalDatasource {

    private long idGameModel;
    private StructureModel structureModel;
    private DatabaseManager databaseManager = DatabaseManagerImpl.getInstance();

    public HelperSaveStructureNewGameLocalDatasource initValues(
        long idGameModel,
        StructureModel structureModel
    ) {
        this.idGameModel = idGameModel;
        this.structureModel = structureModel;
        return this;
    }

    public async Task<bool> saveStructure() {
        StructureEntity structureEntity = new StructureEntity();
        structureEntity.gameModelId = idGameModel;
        structureEntity.typeStructureId = structureModel.currentStructure.getIdDB();
        await databaseManager.deleteElementsWithCondition<StructureEntity>(conditions: getListConditions());
        await databaseManager.insert(element: structureEntity);
        return true;
    }

    //private methods
    private List<Condition> getListConditions()
    {
        List<Condition> listConditions = new List<Condition>();

        Condition condition = new Condition();
        condition.columnName = "gameModelId";
        condition.type = TypeElement.INTEGER;
        condition.value = idGameModel;

        listConditions.Add(condition);

        return listConditions;
    }
}