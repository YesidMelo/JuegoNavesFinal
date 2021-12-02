using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  SpacecraftPlayerGetMaxLifeUseCase 
{
    float invoke();
}

public class SpacecraftPlayerGetMaxLifeUseCaseImpl : SpacecraftPlayerGetMaxLifeUseCase
{
    private SpacecraftPlayerLifeRepository repo = new SpacecraftPlayerLifeRepositoryImpl();

    public float invoke() => repo.maxLife;
    
}
