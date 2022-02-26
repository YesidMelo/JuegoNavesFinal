using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerRepository {

    GameObject getCurrentMaterialSpawmer();
    List<GameObject> getAllListMaterial();
    void setCurrentMaterialSpawmer(GameObject materialSpawmer);
    void addMaterial(GameObject materialObject, Level level, Material material);
    void removeMaterial(GameObject gameObject, Level level, Material material);
    void clearCache();
}

public class MaterialSpawmerRepositoryImpl: MaterialSpawmerRepository {

    private MaterialSpawmerCache materialSpawmerCache = MaterialSpawmerCacheImpl.getInstance();

    public void addMaterial(GameObject materialObject, Level level, Material material) => materialSpawmerCache.addMaterial(materialObject: materialObject, level: level, material: material);

    public void clearCache() => materialSpawmerCache.destroyInstance();

    public List<GameObject> getAllListMaterial() => materialSpawmerCache.listAllMaterials();

    public GameObject getCurrentMaterialSpawmer() => materialSpawmerCache.currentSpawmerGenerator;
   
    public void removeMaterial(GameObject gameObject, Level level, Material material) => materialSpawmerCache.removeMaterial(gameObject: gameObject, level: level, material: material);

    public void setCurrentMaterialSpawmer(GameObject materialSpawmer) => materialSpawmerCache.currentSpawmerGenerator = materialSpawmer;
}