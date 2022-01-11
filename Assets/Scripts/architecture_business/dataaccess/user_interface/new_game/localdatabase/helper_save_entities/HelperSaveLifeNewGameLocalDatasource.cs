using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperSaveLifeNewGameLocalDatasource {

    private long idGameModel;
    private LifeModel lifeModel;
    private DatabaseManager dbManager = DatabaseManagerImpl.getInstance();

    public HelperSaveLifeNewGameLocalDatasource initValues(
        long idGameModel,
        LifeModel lifeModel
    ) {
        this.idGameModel = idGameModel;
        this.lifeModel = lifeModel;
        return this;
    }

    public async Task<bool> saveLife() {
        LifeEntity lifeEntity = new LifeEntity();
        lifeEntity.life = lifeModel.life;
        lifeEntity.maxLife = lifeModel.maxLife;
        lifeEntity.gameModelId = idGameModel;
        await dbManager.deleteElementsWithCondition<LifeEntity>(conditions: getListConditions()) ;
        await dbManager.insert<LifeEntity>(element: lifeEntity);
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