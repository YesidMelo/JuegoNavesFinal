using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialsCache {

    Material getRandomMaterial();
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
    public Material getRandomMaterial()
    {
        Array listMaterials = Enum.GetValues(typeof(Material));
        System.Random random = new System.Random();
        Material material = (Material)listMaterials.GetValue(random.Next(listMaterials.Length));
        return material;
    }

    public void destroyInstance() => instance = null;
    
}
