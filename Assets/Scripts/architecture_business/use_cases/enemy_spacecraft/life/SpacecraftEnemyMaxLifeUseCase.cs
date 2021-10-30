using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyMaxLifeUseCase {
    int invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyMaxLifeUseCaseImpl : SpacecraftEnemyMaxLifeUseCase
{
    
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();

    public int invoke(IdentificatorModel identificator) => repo.maxLife(identificator);
}