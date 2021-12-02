using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyMaxLifeUseCase {
    float invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyMaxLifeUseCaseImpl : SpacecraftEnemyMaxLifeUseCase
{
    
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();

    public float invoke(IdentificatorModel identificator) => repo.maxLife(identificator);
}