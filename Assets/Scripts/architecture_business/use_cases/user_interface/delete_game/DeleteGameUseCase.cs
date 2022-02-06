using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface DeleteGameUseCase {
    Task<bool> invoke(GameModel gameModel);
}

public class DeleteGameUseCaseImpl : DeleteGameUseCase
{
    private DeleteGameRepository deleteGameRepository = new DeleteGameRepositoryImpl();
    public async Task<bool> invoke(GameModel gameModel) => await deleteGameRepository.deleteGame(gameModel: gameModel);
}