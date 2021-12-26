using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerStorageCache {
    StoragePlayer currentStorage { get; }
    StorageModel currentStorageModel { get; }
    bool loadStorage();
    void updateStorage(StoragePlayer storage);
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

    //variables

    private StoragePlayer _currentStorage = StoragePlayer.TYPE_1;
    private StorageModel _currentStorageModel = new StorageModel();

    private SpacecraftPlayerStorageCacheImpl() { }

    public StoragePlayer currentStorage => _currentStorage;

    public StorageModel currentStorageModel => _currentStorageModel;

    public bool loadStorage() {
        _currentStorageModel.currentStorage = _currentStorage;
        return true; 
    }

    public void updateStorage(StoragePlayer storage) {
        _currentStorage = storage;
        _currentStorageModel.currentStorage = _currentStorage;
    }
}