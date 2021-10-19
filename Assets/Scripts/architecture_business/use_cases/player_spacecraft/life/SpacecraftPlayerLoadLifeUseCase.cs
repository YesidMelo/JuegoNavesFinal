using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLoadLifeUseCase {
    bool invoke();
}

public class SpacecraftPlayerLoadLifeUseCaseImpl : SpacecraftPlayerLoadLifeUseCase
{
    private SpacecraftPlayerLifeRepository repoLife = new SpacecraftPlayerLifeRepositoryImpl();
    public bool invoke() => repoLife.loadLife();
}