using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperSaveLaserNewGameLocalDatasource {

    private LaserModel laserModel;
    private long idGameModel;
    private DatabaseManager databaseManager = DatabaseManagerImpl.getInstance();

    public HelperSaveLaserNewGameLocalDatasource initValues(LaserModel laserModel, long idGameModel) {
        this.laserModel = laserModel;
        this.idGameModel = idGameModel;
        return this;
    }

    public async Task<bool> saveLaserModel() {
        this.laserModel.gameModelId = this.idGameModel;
        List<LaserEntity> listLaserEntities = generateListLaserEntities();
        await databaseManager.insertAll(listLaserEntities);
        return true;
    }

    //private methods
    private List<LaserEntity> generateListLaserEntities() {
        List<LaserEntity> laserEntities = new List<LaserEntity>();
        foreach (LaserPlayer currentLaser in laserModel.listLasers) {
            LaserEntity laserEntity = new LaserEntity();
            laserEntity.gameModelId = idGameModel;
            laserEntity.typeLaserId = currentLaser.getIdDB();
            laserEntities.Add(laserEntity);
        }
        return laserEntities;
    }
}