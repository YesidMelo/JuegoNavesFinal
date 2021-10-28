using System.Collections;
using UnityEngine;

public interface SpacecraftEnemyLaserRepository {
    SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator);
    void deleteLasers(IdentificatorModel identificator);
    int impactLaser(IdentificatorModel identificator);
    bool loadSpacecraft(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    LaserEnemy typeLaser(IdentificatorModel identificator);
}

public class SpacecraftEnemyLaserRepositoryImpl : SpacecraftEnemyLaserRepository
{
    private SpacecraftEnemyLasersCache cache = SpacecraftEnemyLasersCacheImpl.getInstance();

    public SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator) => cache.currentSpacecraft(identificator);

    public void deleteLasers(IdentificatorModel identificator) => cache.deleteLasers(identificator);

    public int impactLaser(IdentificatorModel identificator) => cache.impactLaser(identificator);

    public bool loadSpacecraft(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => cache.loadSpacecraft(identificator, spacecraft);

    public LaserEnemy typeLaser(IdentificatorModel identificator) => cache.typeLaser(identificator);
}