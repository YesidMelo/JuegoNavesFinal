using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyStorageCache {
    StorageEnemy currentStorage(IdentificatorModel identificator);
    bool loadStorage(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeStorage(IdentificatorModel identificator);
    void clearCache();
}

public class SpacecraftEnemyStorageCacheImpl : SpacecraftEnemyStorageCache
{
    //static variables
    private static SpacecraftEnemyStorageCacheImpl instance;

    //static methods
    public static SpacecraftEnemyStorageCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftEnemyStorageCacheImpl();
        }
        return instance;
    }

    private Dictionary<IdentificatorModel, StorageEnemy> _dictionaryStorages = new Dictionary<IdentificatorModel, StorageEnemy>();
    private Dictionary<IdentificatorModel, SpacecraftEnemy> _dictionarySpacecraft = new Dictionary<IdentificatorModel, SpacecraftEnemy>();


    public StorageEnemy currentStorage(IdentificatorModel identificator) => _dictionaryStorages[identificator];

    public bool loadStorage(IdentificatorModel identificator, SpacecraftEnemy spacecraft)
    {
        _dictionarySpacecraft[identificator] = spacecraft;
        _dictionaryStorages[identificator] = loadCurrentStorage(spacecraft);
        return true;
    }

    public void removeStorage(IdentificatorModel identificator)
    {
        if (!_dictionaryStorages.ContainsKey(identificator)) return;
        _dictionaryStorages.Remove(identificator);
        _dictionarySpacecraft.Remove(identificator);
    }

    public void clearCache()
    {
        _dictionaryStorages.Clear();
        _dictionarySpacecraft.Clear();
    }

    //private methods
    StorageEnemy loadCurrentStorage(SpacecraftEnemy spacecraft) {
        StorageEnemy finalStorage;
        switch (spacecraft) {
            case SpacecraftEnemy.NIVEL1_LIEUTENENTS:
                finalStorage = StorageEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.NIVEL1_MAJOR:
                finalStorage = StorageEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.NIVEL1_LIEUTENANTCOLONEL:
                finalStorage = StorageEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.NIVEL1_COLONEL:
                finalStorage = StorageEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.NIVEL1_SECOND_LIEUTENANTS:
            default:
                finalStorage = StorageEnemy.TYPE_1;
                break;
        }
        return finalStorage;
    }

}