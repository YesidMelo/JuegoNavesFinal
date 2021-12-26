using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGameDatabaseDatasource {
    Task<List<GameModel>> loadListGamesSaved();
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


    private LoadGameDatabaseDatasourceImpl() { }

    public async Task<List<GameModel>> loadListGamesSaved()
    {

        List<GameEntity> listEntities = await DatabaseManagerImpl.getInstance().getElements<GameEntity>(conditions: new List<Condition>());

        ChangeBetweenObject<GameEntity, GameModel> converter = new ChangeBetweenObject<GameEntity, GameModel>();

        List<GameModel> listModels = converter.transformList(listInput: listEntities);
        return listModels;
    }

    

}