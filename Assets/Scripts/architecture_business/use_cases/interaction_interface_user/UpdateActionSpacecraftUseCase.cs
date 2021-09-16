using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UpdateActionSpacecraftUseCase {
    void invoke(Action action);
}

public class UpdateActionSpacecraftUseCaseImpl : UpdateActionSpacecraftUseCase
{
    private InteractionInterfaceUserRepository joysticRepository = new InteractionInterfaceUserRepositoryImpl();

    public void invoke(Action action) => joysticRepository.updateActionSpacecraft(action);
}
