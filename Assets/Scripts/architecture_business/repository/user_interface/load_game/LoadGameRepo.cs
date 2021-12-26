using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGameRepo
{
    Task<List<GameModel>> loadListGamesSaved();
}

public class LoadGameRepositoryImpl : LoadGameRepo
{

    private LoadGameDatabaseDatasource loadGameDatabaseDatasource = LoadGameDatabaseDatasourceImpl.getInstance();

    public async Task<List<GameModel>> loadListGamesSaved() => await loadGameDatabaseDatasource.loadListGamesSaved();
}