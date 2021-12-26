using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HelperSaveRadarNewGameLocalDatasource {

    private long idGameModel;
    private RadarModel radarModel;
    private DatabaseManager databaseManager = DatabaseManagerImpl.getInstance();

    public HelperSaveRadarNewGameLocalDatasource initValues(
        long idGameModel,
        RadarModel radarModel
    ) {
        this.radarModel = radarModel;
        this.idGameModel = idGameModel;
        return this;
    }

    public async Task<bool> saveRadar() {
        RadarEntitty radarEntitty = new RadarEntitty();
        radarEntitty.gameModelId = idGameModel;
        radarEntitty.typeRadarId = radarModel.currentRadarPlayer.getTypeRadarIdDB();
        await databaseManager.insert(element: radarEntitty);
        return true;
    }

}
