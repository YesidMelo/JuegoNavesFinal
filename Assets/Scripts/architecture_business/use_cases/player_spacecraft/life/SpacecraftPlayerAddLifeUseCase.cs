using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerAddLifeUseCase {
    public void invoke(float life);
}

public class SpacecraftPlayerAddLifeUseCaseImpl : SpacecraftPlayerAddLifeUseCase
{
    private SpacecraftPlayerLifeRepository repo = new SpacecraftPlayerLifeRepositoryImpl();
    public void invoke(float life) => repo.addLife(life);
}