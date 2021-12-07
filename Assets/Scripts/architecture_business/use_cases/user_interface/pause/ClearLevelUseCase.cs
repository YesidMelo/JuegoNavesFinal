using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface ClearLevelUseCase {
    Task<bool> invoke();

}

public class ClearLevelUseCaseImpl : ClearLevelUseCase
{
    private InteractionInterfaceUserRepository interactionInterfaceUserRepository = new InteractionInterfaceUserRepositoryImpl();
    private StagePopulationRepository stagePopulationRepository = new StagePopulationRepositoryImpl();

    public async Task<bool> invoke()
    {
        await Task.Delay(1000);
        return true;
    }
}