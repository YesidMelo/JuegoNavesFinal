using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerAddLifeUseCase {
    public void invoke(float life);
}

public class SpacecraftPlayerAddLifeUseCaseImpl : SpacecraftPlayerAddLifeUseCase
{
    private SpacecraftPlayerRepository repo = new SpacecraftPlayerRepositoryImpl();
    public void invoke(float life) => repo.addLife(life);
}
