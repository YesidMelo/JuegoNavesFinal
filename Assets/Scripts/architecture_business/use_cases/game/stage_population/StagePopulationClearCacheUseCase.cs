using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface StagePopulationClearCacheUseCase {
    Task<bool> invoke();
}
public class StagePopulationClearCacheUseCaseImpl : StagePopulationClearCacheUseCase
{
    private StagePopulationRepository repo = new StagePopulationRepositoryImpl();

    public async Task<bool> invoke() => repo.clearCache();
    
}