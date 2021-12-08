using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameLocalDatasource {
    Task<bool> saveGame(GameModel gameModel);
    Task<bool> loadGame();
    Task<bool> loadListGamesAvailables();
}

public class NewGameLocalDatasourceImpl : NewGameLocalDatasource
{
    public async Task<bool> loadGame()
    {
        await Task.Delay(1000);
        return true;
    }

    public async Task<bool> loadListGamesAvailables()
    {
        await Task.Delay(1000);
        return true;
    }

    public async Task<bool> saveGame(GameModel gameModel)
    {
        return true;
    }
}