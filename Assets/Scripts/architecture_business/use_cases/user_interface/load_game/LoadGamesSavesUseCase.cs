using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGamesSavesUseCase {
    Task<List<GameGalacticToSaveModel>> invoke();
}

public class LoadGamesSavesUseCaseImpl : LoadGamesSavesUseCase
{
    private LoadGameRepo loadGameRepository = new LoadGameRepositoryImpl();

    public async Task<List<GameGalacticToSaveModel>> invoke() => await loadGameRepository.loadListGamesSaved();
}