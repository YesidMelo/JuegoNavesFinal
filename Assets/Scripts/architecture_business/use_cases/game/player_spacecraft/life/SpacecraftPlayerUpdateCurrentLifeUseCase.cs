using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerUpdateCurrentLifeUseCase {
    void invoke(float life);
}
public class SpacecraftPlayerUpdateCurrentLifeUseCaseImpl : SpacecraftPlayerUpdateCurrentLifeUseCase
{
    private SpacecraftPlayerLifeRepository repo = new SpacecraftPlayerLifeRepositoryImpl();

    public void invoke(float life) => repo.updateCurrentLife(life);
}