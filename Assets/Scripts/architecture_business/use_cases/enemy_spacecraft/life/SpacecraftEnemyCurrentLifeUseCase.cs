using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCurrentLifeUseCase {
    int invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyCurrentLifeUseCaseImpl : SpacecraftEnemyCurrentLifeUseCase
{
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();

    public int invoke(IdentificatorModel identificator) => repo.currentLife(identificator);
}