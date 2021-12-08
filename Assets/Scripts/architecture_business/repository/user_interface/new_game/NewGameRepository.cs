using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameRepository {

    Task<bool> setNewGameModel(GameModel newGameModel);
    Task<GameModel> getCurrentNewGameModel();

    Task<bool> saveGame(GameModel gameModel);
    Task<bool> loadGame();
    Task<bool> loadListGamesAvailables();

}

public class NewGameRepositoryImpl : NewGameRepository
{

    private NewGameCache cache = NewGameCacheImpl.getInstance();
    private NewGameLocalDatasource localDatasource = new NewGameLocalDatasourceImpl();

    public async Task<GameModel> getCurrentNewGameModel() { 
        return await cache.currentNewGameModel(); 
    }

    public async Task<bool> loadGame() => await localDatasource.loadGame();

    public async Task<bool> loadListGamesAvailables() => await localDatasource.loadListGamesAvailables();

    public async Task<bool> saveGame(GameModel gameModel) => await localDatasource.saveGame(gameModel: gameModel);

    public async Task<bool> setNewGameModel(GameModel newGameModel) { 
        return await cache.setNewGame(newGameModel: newGameModel);
    }
}