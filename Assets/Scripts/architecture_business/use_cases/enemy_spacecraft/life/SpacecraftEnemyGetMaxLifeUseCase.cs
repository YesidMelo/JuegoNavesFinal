using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetMaxLifeUseCase {
    float invoke(IdentificatorModel identificatorModel);
}

public class SpacecraftEnemyGetMaxLifeUseCaseImpl : SpacecraftEnemyGetMaxLifeUseCase
{
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();
    public float invoke(IdentificatorModel identificatorModel) => repo.maxLife(identificatorModel);
}