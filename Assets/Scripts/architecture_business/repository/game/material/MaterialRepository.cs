using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialRepository {
    Material getRandomMaterial();
    void clearCache();
}

public class MaterialRepositoryImpl : MaterialRepository
{
    private MaterialsCache cache = MaterialsCacheImpl.getInstance();

    public void clearCache() => cache.destroyInstance();

    public Material getRandomMaterial() => cache.getRandomMaterial();
}