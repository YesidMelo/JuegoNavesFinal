using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCurrentLifeUseCase {
    float invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyCurrentLifeUseCaseImpl : SpacecraftEnemyCurrentLifeUseCase
{
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();

    public float invoke(IdentificatorModel identificator) => repo.currentLife(identificator);
}