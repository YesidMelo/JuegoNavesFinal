using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameRepository {

    Task<bool> setNewGameModel(NewGameModel newGameModel);
    Task<NewGameModel> getCurrentNewGameModel();

    Task<bool> saveGame();
    Task<bool> loadGame();
    Task<bool> loadListGamesAvailables();

}

public class NewGameRepositoryImpl : NewGameRepository
{

    private NewGameCache cache = NewGameCacheImpl.getInstance();
    private NewGameLocalDatasource localDatasource = new NewGameLocalDatasourceImpl();

    public async Task<NewGameModel> getCurrentNewGameModel() { 
        return await cache.currentNewGameModel(); 
    }

    public async Task<bool> loadGame() => await localDatasource.loadGame();

    public async Task<bool> loadListGamesAvailables() => await localDatasource.loadListGamesAvailables();

    public async Task<bool> saveGame() => await localDatasource.saveGame();

    public async Task<bool> setNewGameModel(NewGameModel newGameModel) { 
        return await cache.setNewGame(newGameModel: newGameModel);
    }
}