using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CurrentMovementJoysticUseCase {
    Vector2 invoke();
}
public class CurrentMovementJoysticUseCaseImpl : CurrentMovementJoysticUseCase
{
    private InteractionInterfaceUserRepository joysticRepository = new InteractionInterfaceUserRepositoryImpl();

    public Vector2 invoke() => joysticRepository.currentMovementJoystic;
}
