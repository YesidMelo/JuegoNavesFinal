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
        _dictionaryShield[identificator] = loadCurrentShield(spacecraft);
        return true;
    }

    public void removeShield(IdentificatorModel identificator)
    {
        if (!_dictionaryShield.ContainsKey(identificator)) return;
        _dictionaryShield.Remove(identificator);
    }

    //private methods
    private ShieldEnemy loadCurrentShield(SpacecraftEnemy spacecraft) {
        ShieldEnemy finalShield;
        switch (spacecraft) {
            case SpacecraftEnemy.NIVEL1_LIEUTENENTS:
                finalShield = ShieldEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.NIVEL1_MAJOR:
                finalShield = ShieldEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.NIVEL1_LIEUTENANTCOLONEL:
                finalShield = ShieldEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.NIVEL1_COLONEL:
                finalShield = ShieldEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.NIVEL1_SECOND_LIEUTENANTS:
            default:
                finalShield = ShieldEnemy.TYPE_1;
                break;
        }
        return finalShield;
    }
}