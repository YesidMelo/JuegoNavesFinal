using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameRepository {

    Task<bool> setNewGameModel(NewGameModel newGameModel);
    Task<NewGameModel> getCurrentNewGameModel();

}

public class NewGameRepositoryImpl : NewGameRepository
{

    private NewGameCache cache = NewGameCacheImpl.getInstance();

    public async Task<NewGameModel> getCurrentNewGameModel() { 
        return await cache.currentNewGameModel(); 
    }

    public async Task<bool> setNewGameModel(NewGameModel newGameModel) { 
        return await cache.setNewGame(newGameModel: newGameModel);
    }
}