using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyShieldCache {
    ShieldEnemy currentShield(IdentificatorModel identificator);
    bool loadShield(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeShield(IdentificatorModel identificator);
}
public class SpacecraftEnemyShieldCacheImpl : SpacecraftEnemyShieldCache
{
    //static variable
    private static SpacecraftEnemyShieldCacheImpl instance;

    //static methods
    public static SpacecraftEnemyShieldCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftEnemyShieldCacheImpl();
        }
        return instance;
    }

    private Dictionary<IdentificatorModel, ShieldEnemy> _dictionaryShield = new Dictionary<IdentificatorModel, ShieldEnemy>();

    public ShieldEnemy currentShield(IdentificatorModel identificator) => _dictionaryShield[identificator];

    public bool loadShield(IdentificatorModel identificator, SpacecraftEnemy spacecraft)
    {
        _dictionaryShield[identificator] = spacecraft.loadCurrentShield();
        return true;
    }

    public void removeShield(IdentificatorModel identificator)
    {
        if (!_dictionaryShield.ContainsKey(identificator)) return;
        _dictionaryShield.Remove(identificator);
    }

    //private methods

}