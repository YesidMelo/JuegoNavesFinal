using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGamesSavesUseCase {
    Task<List<GameModel>> invoke();
}

public class LoadGamesSavesUseCaseImpl : LoadGamesSavesUseCase
{
    private LoadGameRepo loadGameRepository = new LoadGameRepositoryImpl();

    public async Task<List<GameModel>> invoke() => await loadGameRepository.loadListGamesSaved();
}