using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialsCache {

    Material getRandomMaterial();
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

    public Material getRandomMaterial()
    {
        throw new System.NotImplementedException();
    }
}
