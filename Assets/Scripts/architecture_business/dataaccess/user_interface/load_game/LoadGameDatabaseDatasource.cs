using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGameDatabaseDatasource {
    Task<List<GameGalacticToSaveModel>> loadListGamesSaved();
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

    public async Task<List<GameGalacticToSaveModel>> loadListGamesSaved()
    {

        List<GameGalacticToSaveEntity> listEntities = await DatabaseManagerImpl.getInstance().getElements<GameGalacticToSaveEntity>(conditions: new List<Condition>());

        ChangeBetweenObject<GameGalacticToSaveEntity, GameGalacticToSaveModel> converter = new ChangeBetweenObject<GameGalacticToSaveEntity, GameGalacticToSaveModel>();

        List<GameGalacticToSaveModel> listModels = converter.transformList(listInput: listEntities);
        return listModels;
    }

    

}