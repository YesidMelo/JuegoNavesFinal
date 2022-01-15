using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerStorageRepository {
    StoragePlayer currentStorage { get; }
    StorageModel currentStorageModel { get; }
    bool loadStorage();
    void setCurrentStorageModel(StorageModel storageModel);
    void updateStorage(StoragePlayer storage);
    public void clearCache();
}
public class SpacecraftPlayerStorageRepositoryImpl : SpacecraftPlayerStorageRepository
{
    private SpacecraftPlayerStorageCache cache = SpacecraftPlayerStorageCacheImpl.getInstance();

    public StoragePlayer currentStorage => cache.currentStorage;

    public StorageModel currentStorageModel => cache.currentStorageModel;
    public void clearCache() => cache.clearCache();
    public bool loadStorage() => cache.loadStorage();
    public void setCurrentStorageModel(StorageModel storageModel) => cache.setCurrentStorageModel(storageModel: storageModel);
    public void updateStorage(StoragePlayer storage) => cache.updateStorage(storage);
}
