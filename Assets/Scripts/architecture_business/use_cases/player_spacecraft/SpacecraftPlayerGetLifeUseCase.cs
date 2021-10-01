using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetLifeUseCase
{
    float invoke();
}

public class SpacecraftPlayerGetLifeUseCaseImpl : SpacecraftPlayerGetLifeUseCase
{
    private SpacecraftPlayerRepository spacecraftRepository = new SpacecraftPlayerRepositoryImpl();

    public float invoke() => spacecraftRepository.life;
}
