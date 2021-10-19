using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerUpdateCurrentLifeUseCase {
    void invoke(int life);
}
public class SpacecraftPlayerUpdateCurrentLifeUseCaseImpl : SpacecraftPlayerUpdateCurrentLifeUseCase
{
    private SpacecraftPlayerLifeRepository repo = new SpacecraftPlayerLifeRepositoryImpl();

    public void invoke(int life) => repo.updateCurrentLife(life);
}