using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SetCurrentSpawmPopulationUseCase {
    void invoke(GameObject spawmPopulation);
}

public class SetCurrentSpawmPopulationUseCaseImpl : SetCurrentSpawmPopulationUseCase
{

    private InteractionInterfaceUserRepository interfaceUserRepository = new InteractionInterfaceUserRepositoryImpl();

    public void invoke(GameObject spawmPopulation) {
        interfaceUserRepository.setCurrentSpawmPopulation(spawmPopulation: spawmPopulation);
    }
}