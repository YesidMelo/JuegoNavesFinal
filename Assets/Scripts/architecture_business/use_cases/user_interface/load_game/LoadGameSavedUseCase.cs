using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGameSavedUseCase {
    public Task invoke(GameModel gameModel);
}

public class LoadGameSavedUseCaseImpl : LoadGameSavedUseCase
{
    private LoadGameRepo loadGameRepo = new LoadGameRepositoryImpl();

    public async Task invoke(GameModel gameModel)
    {
        await loadGameRepo.loadGameModel(gameModel: gameModel);
    }
}