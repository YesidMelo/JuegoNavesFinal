using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyStorageRepository {
    StorageEnemy currentStorage(IdentificatorModel identificator);
    bool loadStorage(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    void removeStorage(IdentificatorModel identificator);
}
public class SpacecraftEnemyStorageRepositoryImpl : SpacecraftEnemyStorageRepository
{
    private SpacecraftEnemyStorageCache cache = SpacecraftEnemyStorageCacheImpl.getInstance();

    public StorageEnemy currentStorage(IdentificatorModel identificator) => cache.currentStorage(identificator);

    public bool loadStorage(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => cache.loadStorage(identificator, spacecraft);

    public void removeStorage(IdentificatorModel identificator) => cache.removeStorage(identificator);
}