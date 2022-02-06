using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerStorageCache {
    StoragePlayer currentStorage { get; }
    StorageModel currentStorageModel { get; }
    bool loadStorage();
    void setCurrentStorageModel(StorageModel storageModel);
    void updateStorage(StoragePlayer storage);
    public void clearCache();

}

public class SpacecraftPlayerStorageCacheImpl : SpacecraftPlayerStorageCache
{
    // static variables
    private static SpacecraftPlayerStorageCacheImpl instance;

    //static methods
    public static SpacecraftPlayerStorageCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftPlayerStorageCacheImpl();
        }
        return instance;
    }

    public static void destroyInstance() => instance = null;

    //variables

    private StoragePlayer _currentStorage = StoragePlayer.TYPE_1;
    private StorageModel _currentStorageModel = new StorageModel();

    private SpacecraftPlayerStorageCacheImpl() { }

    public StoragePlayer currentStorage => _currentStorage;

    public StorageModel currentStorageModel => _currentStorageModel;

    public void clearCache()
    {
        _currentStorage = StoragePlayer.TYPE_1;
        _currentStorageModel = new StorageModel();
    }

    public bool loadStorage() {
        _currentStorageModel.currentStorage = _currentStorage;
        return true; 
    }

    public void updateStorage(StoragePlayer storage) {
        _currentStorage = storage;
        _currentStorageModel.currentStorage = _currentStorage;
    }

    public void setCurrentStorageModel(StorageModel storageModel)
    {
        _currentStorageModel = storageModel;
        _currentStorage = currentStorageModel.currentStorage;
    }

}