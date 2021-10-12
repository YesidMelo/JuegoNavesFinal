using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetLifeUseCase {
    float invoke(IdentificatorModel identificatorModel);
}

public class SpacecraftEnemyGetLifeUseCaseImpl : SpacecraftEnemyGetLifeUseCase
{
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();
    public float invoke(IdentificatorModel identificatorModel) => repo.life(identificatorModel);
}