using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyStorageCache {
    StorageEnemy currentStorage(IdentificatorModel identificator);
    bool loadStorage(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeStorage(IdentificatorModel identificator);
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

    //private methods
    StorageEnemy loadCurrentStorage(SpacecraftEnemy spacecraft) {
        StorageEnemy finalStorage;
        switch (spacecraft) {
            case SpacecraftEnemy.NIVEL1_SPACECRAFT2:
                finalStorage = StorageEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT3:
                finalStorage = StorageEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT4:
                finalStorage = StorageEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT5:
                finalStorage = StorageEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.NIVEL1_SPACECRAFT1:
            default:
                finalStorage = StorageEnemy.TYPE_1;
                break;
        }
        return finalStorage;
    }
}