using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GetCurrentSpawmPopulationUseCase {
    GameObject invoke();
}

public class GetCurrentSpawmPopulationUseCaseImpl : GetCurrentSpawmPopulationUseCase
{
    private InteractionInterfaceUserRepository interfaceUserRepository = new InteractionInterfaceUserRepositoryImpl();

    public GameObject invoke() => interfaceUserRepository.currentSpawmPopulation;
}