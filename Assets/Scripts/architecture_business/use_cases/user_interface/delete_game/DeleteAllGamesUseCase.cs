using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface DeleteAllGamesUseCase {
    Task<bool> invoke();
}
public class DeleteAllGamesUseCaseImpl : DeleteAllGamesUseCase
{
    private DeleteGameRepository deleteGameRepository = new DeleteGameRepositoryImpl();

    public async Task<bool> invoke() => await deleteGameRepository.deleteAllGames();
}