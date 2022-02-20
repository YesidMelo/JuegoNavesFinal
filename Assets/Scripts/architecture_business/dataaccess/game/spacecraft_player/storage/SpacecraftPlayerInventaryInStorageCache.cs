using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerInventaryInStorageCache {
    void setCurrentStorageModel(StorageModel storageModel);
    void destroyInstance();

    SpacecraftPlayerInventaryInStorageCache checkMaterialsInStorage();

    Dictionary<Material, int> getListMaterials();
    int totalMaterials();
}

public class SpacecraftPlayerInventaryInStorageCacheImpl : SpacecraftPlayerInventaryInStorageCache
{
    //static variables
    private static SpacecraftPlayerInventaryInStorageCache instance;

    //static methods
    public static SpacecraftPlayerInventaryInStorageCache getInstance() {
        if (instance == null) {
            instance = new SpacecraftPlayerInventaryInStorageCacheImpl();
        }
        return instance;
    }


    //variables
    private StorageModel storageModel;
    private Dictionary<Material, int> listMaterials = new Dictionary<Material, int>();
    private int totalMaterialsInStorage;

    public void destroyInstance() => instance = null;

    public void setCurrentStorageModel(StorageModel storageModel) => this.storageModel = storageModel;

    public Dictionary<Material, int> getListMaterials() => listMaterials;

    public int totalMaterials() => totalMaterialsInStorage;

    public SpacecraftPlayerInventaryInStorageCache checkMaterialsInStorage()
    {
        calculateCurrentMaterialsInStorage();
        return this;
    }


    //private methods
    private bool isListMaterialsFromStorageModelValid() {
        return storageModel == null || storageModel.listMaterials == null || storageModel.listMaterials.Count == 0;
    }

    private void calculateCurrentMaterialsInStorage() {
        totalMaterialsInStorage = 0;

        foreach (Material currentMaterial in Enum.GetValues(typeof(Material)))
        {
            listMaterials[currentMaterial] = 0;
        }

        if (isListMaterialsFromStorageModelValid()) return;


        foreach (MaterialModel material in storageModel.listMaterials)
        {
            listMaterials[material.material] = material.quantity;
            totalMaterialsInStorage += material.quantity; 
        }
    }

}