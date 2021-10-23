using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRepository {
    bool loadSpacecraft(IdentificatorModel identificator);

    SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator);

    void setSpacecraft(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
}

public class SpacecraftEnemyRepositoryImpl : SpacecraftEnemyRepository
{

    private SpacecraftEnemyCache cache = SpacecraftEnemyCacheImpl.getInstance();

    public SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator) => cache.currentSpacecraft(identificator);

    public bool loadSpacecraft(IdentificatorModel identificator) => cache.loadSpacecraft(identificator);

    public void setSpacecraft(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => cache.setSpacecraft(identificator, spacecraft);
}