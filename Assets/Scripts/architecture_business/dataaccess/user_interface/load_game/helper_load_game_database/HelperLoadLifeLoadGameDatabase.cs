using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperLoadLifeLoadGameDatabase {

    public GameModel gameModel;

    public HelperLoadLifeLoadGameDatabase initValues(GameModel gameModel) {
        this.gameModel = gameModel;
        return this;
    }

    public async Task loadLife() {
        try
        {
            List<LifeEntity> listLifeEntity = await DatabaseManagerImpl.getInstance().getElements<LifeEntity>(conditions: generateListConditionsLaser());
            LifeModel lifeModel = convertLifeEntityToLifeModel(listLifeEntity: listLifeEntity);
            gameModel.lifeModel = lifeModel;
        }
        catch (Exception e) {
            Debug.Log(e.Message);
        }
    }

    //private methods
    private List<Condition> generateListConditionsLaser()
    {
        Condition condition = new Condition();
        condition.columnName = "gameModelId";
        condition.value = gameModel.id;
        condition.type = TypeElement.INTEGER;

        List<Condition> listCondition = new List<Condition>();
        listCondition.Add(condition);
        return listCondition;
    }

    private LifeModel convertLifeEntityToLifeModel(List<LifeEntity> listLifeEntity) {
        if (listLifeEntity.Count == 0) return null;
        LifeEntity currentLifeEntity = listLifeEntity[0];

        LifeModel lifeModel = new LifeModel();
        lifeModel.id = currentLifeEntity.id;
        lifeModel.life = currentLifeEntity.life;
        lifeModel.maxLife = currentLifeEntity.maxLife;
        lifeModel.gameModelId = currentLifeEntity.gameModelId;
        lifeModel.typeLifeId = currentLifeEntity.typeLifeId;

        return lifeModel;
    }

}