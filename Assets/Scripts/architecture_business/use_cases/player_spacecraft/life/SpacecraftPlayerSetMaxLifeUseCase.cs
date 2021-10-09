using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerSetMaxLifeUseCase
{
    public void invoke(float life);
}

public class SpacecraftPlayerSetMaxLifeUseCaseImpl : SpacecraftPlayerSetMaxLifeUseCase
{

    private SpacecraftPlayerLifeRepository spacecraftPlayerRepository = new SpacecraftPlayerLifeRepositoryImpl();

    public void invoke(float life)=> spacecraftPlayerRepository.setMaxLife(life: life);
}
