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

    private HelperNewGameLocalDatasource helperNewGameLocalDatasource = new HelperNewGameLocalDatasource();
    private HelperSaveLaserNewGameLocalDatasource helperSaveLaserNewGame = new HelperSaveLaserNewGameLocalDatasource();


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
        long idGame = await helperNewGameLocalDatasource.saveGameEntity(gameModel: gameModel);
        await helperSaveLaserNewGame.initValues(laserModel: gameModel.laserModel, idGameModel: idGame).saveLaserModel();
        Debug.Log($"id game to save = {idGame}");
        return true;
    }

}