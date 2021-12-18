using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGameRepo
{
    Task<List<GameGalacticToSaveModel>> loadListGamesSaved();
}

public class LoadGameRepositoryImpl : LoadGameRepo
{

    private LoadGameDatabaseDatasource loadGameDatabaseDatasource = LoadGameDatabaseDatasourceImpl.getInstance();

    public async Task<List<GameGalacticToSaveModel>> loadListGamesSaved() => await loadGameDatabaseDatasource.loadListGamesSaved();
}