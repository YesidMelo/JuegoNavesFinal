using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialsCache {

    Material getRandomMaterial(Level level);
    void destroyInstance();
}

public class MaterialsCacheImpl : MaterialsCache {

    //static variables
    private static MaterialsCache instance;

    //static methods
    public static MaterialsCache getInstance() {
        if (instance == null) {
            instance = new MaterialsCacheImpl();
        }
        return instance;
    }

    private MaterialsCacheImpl() { }

    //public methods
    public Material getRandomMaterial(Level level)
    {
        Array listMaterials = Enum.GetValues(typeof(Material));
        List<Material> materialAvailableBySpawm = new List<Material>();
        
        foreach (Material currentMaterial in listMaterials) {
            if (level.getMaxMaterial(currentMaterial) <= 0) continue;
            materialAvailableBySpawm.Add(currentMaterial);
        }

        if (materialAvailableBySpawm.Count == 0) {
            return Material.NONE;
        }

        System.Random random = new System.Random();
        Material finishMaterial = materialAvailableBySpawm[random.Next(materialAvailableBySpawm.Count)];
        return finishMaterial;
    }

    public void destroyInstance() => instance = null;
    
}
