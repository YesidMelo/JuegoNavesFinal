using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLifeRepository {
    float currentLife(IdentificatorModel identificator);
    SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator);
    float maxLife(IdentificatorModel identificator);

    void addLife(IdentificatorModel identificator, int life);
    void quitLife(IdentificatorModel identificator, int life);

    bool loadLife(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeLife(IdentificatorModel identificator);
}

public class SpacecraftEnemyLifeRepositoryImpl : SpacecraftEnemyLifeRepository  {

    private SpacecraftEnemyLifeCache cache = SpacecraftEnemyLifeCacheImpl.getInstance();

    public void addLife(IdentificatorModel identificator, int life) => cache.addLife(identificator, life);

    public float currentLife(IdentificatorModel identificator) => cache.currentLife(identificator);

    public SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator) => cache.currentSpacecraft(identificator);

    public bool loadLife(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => cache.loadLife(identificator, spacecraft);

    public float maxLife(IdentificatorModel identificator) => cache.maxLife(identificator);

    public void quitLife(IdentificatorModel identificator, int life) => cache.quitLife(identificator, life);

    public void removeLife(IdentificatorModel identificator) => cache.removeLife(identificator);
}