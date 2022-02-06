using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface DeleteGameRepository {
    Task<bool> deleteAllGames();
    Task<bool> deleteGame(GameModel gameModel);
}

public class DeleteGameRepositoryImpl : DeleteGameRepository
{

    private DeleteGameDatabaseDataSource database = new DeleteGameDatabaseDataSourceImpl();

    public async Task<bool> deleteAllGames() => await database.deleteAllGames();


    public async Task<bool> deleteGame(GameModel gameModel) => await database.deleteGame(gameModel: gameModel);
}