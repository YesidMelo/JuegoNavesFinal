using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyShieldRepository {
    ShieldEnemy currentShield(IdentificatorModel identificator);
    bool loadShield(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeShield(IdentificatorModel identificator);
}
public class SpacecraftEnemyShieldRepositoryImpl : SpacecraftEnemyShieldRepository
{
    private SpacecraftEnemyShieldCache cache = SpacecraftEnemyShieldCacheImpl.getInstance();

    public ShieldEnemy currentShield(IdentificatorModel identificator) => cache.currentShield(identificator);

    public bool loadShield(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => cache.loadShield(identificator, spacecraft);

    public void removeShield(IdentificatorModel identificator) => cache.removeShield(identificator);
}