using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UpdateMovementJoysticUseCase {
    void invoke(Vector2 direction);
}

public class UpdateMovementJoysticUseCaseImpl : UpdateMovementJoysticUseCase
{
    private InteractionInterfaceUserRepository joysticRepository = new InteractionInterfaceUserRepositoryImpl();

    public void invoke(Vector2 direction) => joysticRepository.updateMovementJoystic(direction);
}
