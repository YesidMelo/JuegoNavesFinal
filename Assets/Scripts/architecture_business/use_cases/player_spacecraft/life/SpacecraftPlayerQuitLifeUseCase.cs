using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerQuitLifeUseCase 
{
    public void invoke(float life);
}

public class SpacecraftPlayerQuitLifeUseCaseImpl : SpacecraftPlayerQuitLifeUseCase
{
    private SpacecraftPlayerLifeRepository repo = new SpacecraftPlayerLifeRepositoryImpl();
    public void invoke(float life) => repo.quitLife(life);
}