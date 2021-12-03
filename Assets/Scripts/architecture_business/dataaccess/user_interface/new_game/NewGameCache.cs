using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameCache {
    Task<bool> setNewGame(NewGameModel newGameModel);
    Task<NewGameModel> currentNewGameModel();
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

    private NewGameModel _currentNewGameModel;

    public async Task<NewGameModel> currentNewGameModel() {
        await Task.Delay(1000);
        return _currentNewGameModel; 
    }

    public async Task<bool> setNewGame(NewGameModel newGameModel)
    {
        _currentNewGameModel = newGameModel;
        await Task.Delay(1000);
        return true;
    }
}