using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface DeleteCurrentSpawmPopulationUseCase {
    Task invoke();
}

public class DeleteCurrentSpawmPopulationUseCaseImpl : DeleteCurrentSpawmPopulationUseCase
{
    private InteractionInterfaceUserRepository interactionInterfaceRepository = new InteractionInterfaceUserRepositoryImpl();

    public async Task invoke() => await interactionInterfaceRepository.deleteCurrentSpawmPopulation();
}