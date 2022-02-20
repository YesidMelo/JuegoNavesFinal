using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerStorageRepository {
    //storage
    StoragePlayer currentStorage { get; }
    StorageModel currentStorageModel { get; }
    bool loadStorage();
    void setCurrentStorageModel(StorageModel storageModel);
    void updateStorage(StoragePlayer storage);
    public void clearCache();

    //inventary
    public int totalMaterialsInStorage();
    public Dictionary<Material, int> getListMaterials();

}
public class SpacecraftPlayerStorageRepositoryImpl : SpacecraftPlayerStorageRepository
{
    private SpacecraftPlayerStorageCache storageCache = SpacecraftPlayerStorageCacheImpl.getInstance();
    private SpacecraftPlayerInventaryInStorageCache inventaryCache = SpacecraftPlayerInventaryInStorageCacheImpl.getInstance();

    //storage
    public StoragePlayer currentStorage => storageCache.currentStorage;

    public StorageModel currentStorageModel => storageCache.currentStorageModel;

    public void clearCache() { 
        SpacecraftPlayerStorageCacheImpl.destroyInstance();
        inventaryCache.destroyInstance();
    }

    public bool loadStorage() => storageCache.loadStorage();
    public void setCurrentStorageModel(StorageModel storageModel) {
        storageCache.setCurrentStorageModel(storageModel: storageModel);
        inventaryCache.setCurrentStorageModel(storageModel: storageModel);
    }

    public void updateStorage(StoragePlayer storage) => storageCache.updateStorage(storage);

    //inventary

    public Dictionary<Material, int> getListMaterials() => inventaryCache.checkMaterialsInStorage().getListMaterials();

    public int totalMaterialsInStorage() => inventaryCache.checkMaterialsInStorage().totalMaterials();

}
