using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CurrentActionSpacecraftUseCase {
    Action invoke();
}

public class CurrentActionSpacecraftUseCaseImpl : CurrentActionSpacecraftUseCase
{
    private InteractionInterfaceUserRepository joysticRepository = new InteractionInterfaceUserRepositoryImpl();

    public Action invoke() => joysticRepository.currentActionSpacecraft;
}
