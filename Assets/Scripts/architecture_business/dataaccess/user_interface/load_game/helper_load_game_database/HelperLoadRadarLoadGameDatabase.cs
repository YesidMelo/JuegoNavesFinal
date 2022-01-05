using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperLoadRadarLoadGameDatabase {

    private GameModel gameModel;

    //public methods
    public HelperLoadRadarLoadGameDatabase initValues(GameModel gameModel)
    {
        this.gameModel = gameModel;
        return this;
    }

    public async Task loadRadar() {
        try {
            List<RadarEntitty> listRadarEntity = await DatabaseManagerImpl.getInstance().getElements<RadarEntitty>(conditions: generateListConditionsRadar());
            RadarModel radarModel = convertRadarEntityToRadarModel(listRadarEntity: listRadarEntity);
            gameModel.radarModel = radarModel;

        } catch (Exception e) {
            Debug.Log(e.Message);
        }
    }

    //private methods
    private List<Condition> generateListConditionsRadar()
    {
        Condition condition = new Condition();
        condition.columnName = "gameModelId";
        condition.value = gameModel.id;
        condition.type = TypeElement.INTEGER;

        List<Condition> listCondition = new List<Condition>();
        listCondition.Add(condition);
        return listCondition;
    }

    private RadarModel convertRadarEntityToRadarModel(List<RadarEntitty> listRadarEntity) {
        if (listRadarEntity.Count == 0) return null;
        RadarEntitty currentRadarEntity = listRadarEntity[0];
        
        RadarModel radarModel = new RadarModel();
        radarModel.id = currentRadarEntity.id;
        radarModel.gameModelId = currentRadarEntity.gameModelId;
        radarModel.currentRadarPlayer = RadarPlayer.TYPE_1.getTypeRadarByIdDB(currentRadarEntity.typeRadarId);
        return radarModel;
    }

}