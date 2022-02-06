using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCache {

    bool loadSpacecraft(IdentificatorModel identificator);

    SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator);

    void setSpacecraft(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
}

public class SpacecraftEnemyCacheImpl : SpacecraftEnemyCache
{
    //static variables
    private static SpacecraftEnemyCacheImpl instance;

    //static methods
    public static SpacecraftEnemyCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftEnemyCacheImpl();
        }
        return instance;
    }

    public static void destroyInstance() => instance = null;

    //private variables
    private Dictionary<IdentificatorModel, SpacecraftEnemy> _dictionarySpacecrafts = new Dictionary<IdentificatorModel, SpacecraftEnemy>();
    private SpacecraftEnemyCacheImpl() { }

    //public methods
    public bool loadSpacecraft(IdentificatorModel identificator)
    {
        if (!_dictionarySpacecrafts.ContainsKey(identificator)) {
            setSpacecraft(identificator, SpacecraftEnemy.SECOND_LIEUTENANTS);
            return true;
        }
        return true;
    }

    public SpacecraftEnemy currentSpacecraft(IdentificatorModel identificator) => _dictionarySpacecrafts[identificator];
    
    public void setSpacecraft(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => _dictionarySpacecrafts[identificator] = spacecraft;


}