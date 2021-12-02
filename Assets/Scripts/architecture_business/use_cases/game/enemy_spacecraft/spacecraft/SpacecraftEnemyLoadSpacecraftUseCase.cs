using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLoadSpacecraftUseCase {
    bool invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyLoadSpacecraftUseCaseImpl : SpacecraftEnemyLoadSpacecraftUseCase
{
    private SpacecraftEnemyRepository repo = new SpacecraftEnemyRepositoryImpl();
    public bool invoke(IdentificatorModel identificator) => repo.loadSpacecraft(identificator);
}