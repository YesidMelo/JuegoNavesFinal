using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerStorageRepository {
    StoragePlayer currentStorage { get; }
    StorageModel currentStorageModel { get; }
    bool loadStorage();
    void updateStorage(StoragePlayer storage);
}
public class SpacecraftPlayerStorageRepositoryImpl : SpacecraftPlayerStorageRepository
{
    private SpacecraftPlayerStorageCache cache = SpacecraftPlayerStorageCacheImpl.getInstance();

    public StoragePlayer currentStorage => cache.currentStorage;

    public StorageModel currentStorageModel => cache.currentStorageModel;

    public bool loadStorage() => cache.loadStorage();

    public void updateStorage(StoragePlayer storage) => cache.updateStorage(storage);
}
