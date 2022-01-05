using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperLoadShieldLoadGameDatabase {

    private GameModel gameModel;

    //public methods
    public HelperLoadShieldLoadGameDatabase initValues(GameModel gameModel)
    {
        this.gameModel = gameModel;
        return this;
    }

    public async Task loadShield() {
        try {
            List<ShieldEntity> listShieldEntity = await DatabaseManagerImpl.getInstance().getElements<ShieldEntity>(conditions: generateListConditionsShield());
            ShieldModel shieldModel = convertShieldEntityToShieldModel(shieldEntities: listShieldEntity);
            gameModel.shieldModel = shieldModel;
        }   
        catch (Exception e) {
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

    private ShieldModel convertShieldEntityToShieldModel(List<ShieldEntity> shieldEntities) {
        if (shieldEntities.Count == 0) return null;
        ShieldEntity shieldEntity = shieldEntities[0];

        ShieldModel shieldModel = new ShieldModel();
        shieldModel.id = shieldEntity.id;
        shieldModel.gameModelId = shieldEntity.gameModelId;
        shieldModel.currentShield = ShieldPlayer.TYPE_1.getShieldPlayerByIdDB(id: shieldEntity.typeShieldId);

        return shieldModel;
    }

}