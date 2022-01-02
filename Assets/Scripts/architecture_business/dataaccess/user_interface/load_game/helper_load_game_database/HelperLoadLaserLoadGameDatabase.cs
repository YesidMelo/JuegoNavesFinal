using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperLoadLaserLoadGameDatabase {

    private GameModel gameModel;

    //public methods
    public HelperLoadLaserLoadGameDatabase setLoadGameModel(GameModel gameModel) {
        this.gameModel = gameModel;
        return this;
    }

    public async Task loadLasers() {
        try
        {
            List<LaserEntity> laserEntity = await DatabaseManagerImpl.getInstance().getElements<LaserEntity>(generateListConditionsLaser());
            LaserModel laserModel = convertLaserEntityToLaserModel(lasersEntities: laserEntity);
            gameModel.laserModel = laserModel;
        } catch (Exception e) {
            Debug.Log(e.Message);
        }
    }

    //private methods
    private List<Condition> generateListConditionsLaser() {
        Condition condition = new Condition();
        condition.columnName = "gameModelId";
        condition.value = gameModel.id;
        condition.type = TypeElement.INTEGER;

        List<Condition> listCondition = new List<Condition>();
        listCondition.Add(condition);
        return listCondition;
    }

    private LaserModel convertLaserEntityToLaserModel(List<LaserEntity> lasersEntities) {
        LaserModel laserModel = new LaserModel();
        laserModel.listLasers = new List<LaserPlayer>();

        foreach (LaserEntity laser in lasersEntities) {
            if (laserModel.id == null) laserModel.id = laser.id;
            if (laserModel.gameModelId == null) laserModel.gameModelId = laser.gameModelId;
            laserModel.listLasers.Add(LaserPlayer.TYPE_1.getLaserPlayerById(id: laser.typeLaserId));
        }

        return laserModel;
    }
}