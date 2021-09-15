using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UpdateMovementJoysticUseCase {
    void invoke(Vector2 direction);
}

public class UpdateMovementJoysticUseCaseImpl : UpdateMovementJoysticUseCase
{
    private JoysticRepository joysticRepository = new JoysticRepositoryImpl();

    public void invoke(Vector2 direction) => joysticRepository.updateMovementJoystic(direction);
}
