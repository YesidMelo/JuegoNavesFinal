using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetLifeUseCase
{
    float invoke();
}

public class SpacecraftPlayerGetLifeUseCaseImpl : SpacecraftPlayerGetLifeUseCase
{
    private SpacecraftPlayerLifeRepository spacecraftRepository = new SpacecraftPlayerLifeRepositoryImpl();

    public float invoke() => spacecraftRepository.life;
}
