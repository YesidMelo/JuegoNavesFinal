using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerUpdateLifeUseCase
{
    public void invoke(float life);
}

public class SpacecraftPlayerUpdateLifeUseCaseImpl : SpacecraftPlayerUpdateLifeUseCase
{

    private SpacecraftPlayerRepository spacecraftPlayerRepository = new SpacecraftPlayerRepositoryImpl();

    public void invoke(float life)=> spacecraftPlayerRepository.setLife(life: life);
}
