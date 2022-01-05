using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGameDatabaseDatasource {
    Task<List<GameModel>> loadListGamesSaved();
    Task<GameModel> loadGameModel(GameModel gameModel);
}

public class LoadGameDatabaseDatasourceImpl : LoadGameDatabaseDatasource
{
    //static variables
    private static LoadGameDatabaseDatasourceImpl instance;

    //static methods
    public static LoadGameDatabaseDatasourceImpl getInstance() {
        if (instance == null) {
            instance = new LoadGameDatabaseDatasourceImpl();
        }
        return instance;
    }

    private HelperLoadLaserLoadGameDatabase helperLoadLaserLoadGameDatabase = new HelperLoadLaserLoadGameDatabase();
    private HelperLoadLifeLoadGameDatabase helperLoadLifeLoadGameDatabase = new HelperLoadLifeLoadGameDatabase();
    private HelperLoadMotorLoadGameDatabase helperLoadMotorLoadGameDatabase = new HelperLoadMotorLoadGameDatabase();
    private HelperLoadRadarLoadGameDatabase helperLoadRadarLoadGameDatabase = new HelperLoadRadarLoadGameDatabase();
    private HelperLoadShieldLoadGameDatabase helperLoadShieldLoadGameDatabase = new HelperLoadShieldLoadGameDatabase();
    private HelperLoadStorageLoadGameDatabase helperLoadStorageLoadGameDatabase = new HelperLoadStorageLoadGameDatabase();
    private HelperLoadStructureLoadGameDatabase helperLoadStructureLoadGameDatabase = new HelperLoadStructureLoadGameDatabase();

    private LoadGameDatabaseDatasourceImpl() { }

    public async Task<List<GameModel>> loadListGamesSaved()
    {

        List<GameEntity> listEntities = await DatabaseManagerImpl.getInstance().getElements<GameEntity>(conditions: new List<Condition>());

        ChangeBetweenObject<GameEntity, GameModel> converter = new ChangeBetweenObject<GameEntity, GameModel>();

        List<GameModel> listModels = converter.transformList(listInput: listEntities);
        return listModels;
    }

    public async Task<GameModel> loadGameModel(GameModel gameModel)
    {
        await helperLoadLaserLoadGameDatabase.setLoadGameModel(gameModel: gameModel).loadLasers();
        await helperLoadLifeLoadGameDatabase.initValues(gameModel: gameModel).loadLife();
        await helperLoadMotorLoadGameDatabase.initValues(gameModel: gameModel).loadMotors();
        await helperLoadRadarLoadGameDatabase.initValues(gameModel: gameModel).loadRadar();
        await helperLoadShieldLoadGameDatabase.initValues(gameModel: gameModel).loadShield();
        await helperLoadStorageLoadGameDatabase.initValues(gameModel: gameModel).loadStorage();
        await helperLoadStructureLoadGameDatabase.initValues(gameModel: gameModel).loadStructure();

        return gameModel;
    }
}