using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperSaveLifeSupportNewGameLocalDatasource {

    private long idGameModel;
    private LifeSupportModel lifeSupportModel;
    private DatabaseManager databaseManager = DatabaseManagerImpl.getInstance();

    public HelperSaveLifeSupportNewGameLocalDatasource initValues(
        long idGameModel,
        LifeSupportModel lifeSupportModel
    )
    {
        this.lifeSupportModel = lifeSupportModel;
        this.idGameModel = idGameModel;
        return this;
    }

    public async Task<bool> saveLifeSupport()
    {
        LifeSupportEntity lifeSupportEntity = new LifeSupportEntity();
        lifeSupportEntity.id = lifeSupportModel.id;
        lifeSupportEntity.gameModelId = idGameModel;
        lifeSupportEntity.lifeSupportId = lifeSupportModel.currentLifeSupport.getIdDB();
        await databaseManager.deleteElementsWithCondition<RadarEntitty>(conditions: getListConditions());
        await databaseManager.insert(element: lifeSupportEntity);
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
