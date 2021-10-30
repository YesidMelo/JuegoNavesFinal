using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLoadLifeUseCase {
    bool invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyLoadLifeUseCaseImpl : SpacecraftEnemyLoadLifeUseCase
{
    private SpacecraftEnemyLifeRepository repoLife = new SpacecraftEnemyLifeRepositoryImpl();
    private SpacecraftEnemyRepository repoSpacecraft = new SpacecraftEnemyRepositoryImpl();

    public bool invoke(IdentificatorModel identificator) => repoLife.loadLife(identificator, repoSpacecraft.currentSpacecraft(identificator));
}