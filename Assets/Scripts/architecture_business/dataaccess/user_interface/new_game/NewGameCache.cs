using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameCache {
    Task<bool> setNewGame(GameModel newGameModel);
    Task<GameModel> currentNewGameModel();
}

public class NewGameCacheImpl : NewGameCache
{
    //static variables
    private static NewGameCacheImpl instance;

    //static methods
    public static NewGameCacheImpl getInstance() {
        if (instance == null) {
            instance = new NewGameCacheImpl();
        }
        return instance;
    }

    public static void destroyInstance() => instance = null;

    private GameModel _currentNewGameModel;

    public async Task<GameModel> currentNewGameModel() {
        return _currentNewGameModel; 
    }

    public async Task<bool> setNewGame(GameModel newGameModel)
    {
        _currentNewGameModel = newGameModel;
        return true;
    }
}