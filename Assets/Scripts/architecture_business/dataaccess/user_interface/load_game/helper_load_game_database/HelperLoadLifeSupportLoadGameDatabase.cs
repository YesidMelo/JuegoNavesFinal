using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperLoadLifeSupportLoadGameDatabase {

    private GameModel gameModel;

    //public methods
    public HelperLoadLifeSupportLoadGameDatabase initValues(GameModel gameModel)
    {
        this.gameModel = gameModel;
        return this;
    }

    public async Task loadLifeSupport()
    {
        try
        {
            List<LifeSupportEntity> lifeSupportEntities = await DatabaseManagerImpl.getInstance().getElements<LifeSupportEntity>(generateListConditionsLifeSupport());
            LifeSupportModel lifeSupportModel = convertLifeSupportEntityToLifeSupportModel(listLifeSupportEntity: lifeSupportEntities);
            gameModel.lifeSupportModel = lifeSupportModel;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    //private methods
    private List<Condition> generateListConditionsLifeSupport()
    {
        Condition condition = new Condition();
        condition.columnName = "gameModelId";
        condition.value = gameModel.id;
        condition.type = TypeElement.INTEGER;

        List<Condition> listCondition = new List<Condition>();
        listCondition.Add(condition);
        return listCondition;
    }

    private LifeSupportModel convertLifeSupportEntityToLifeSupportModel(List<LifeSupportEntity> listLifeSupportEntity) {
        if (listLifeSupportEntity.Count == 0) return null;
        LifeSupportEntity lifeSupportEntity = listLifeSupportEntity[0];

        LifeSupportModel lifeSupportModel = new LifeSupportModel();
        lifeSupportModel.id = lifeSupportEntity.id;
        lifeSupportModel.gameModelId = lifeSupportEntity.gameModelId;
        lifeSupportModel.currentLifeSupport = LifeSupportPlayer.TYPE_1.findLifeSupportById(id: lifeSupportEntity.lifeSupportId);
        return lifeSupportModel;
    }

}