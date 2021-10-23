using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetCurrentSpacecraftUseCase
{
    SpacecraftEnemy invoke(IdentificatorModel identificatorModel);
}
public class SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl : SpacecraftEnemyGetCurrentSpacecraftUseCase
{
    private SpacecraftEnemyRepository repo = new SpacecraftEnemyRepositoryImpl();

    public SpacecraftEnemy invoke(IdentificatorModel identificatorModel) => repo.currentSpacecraft(identificatorModel);
}