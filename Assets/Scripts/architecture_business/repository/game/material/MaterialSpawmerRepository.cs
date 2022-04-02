using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerRepository {

    GameObject getCurrentMaterialSpawmer();
    List<GameObject> getAllListMaterial();
    List<string> getListNumberMaterialsByLevel(Level level);
    Dictionary<Material, int> bringMissingMaterial(Level level);
    bool isAllMaterialsInLevel(Level level);
    void setCurrentMaterialSpawmer(GameObject materialSpawmer);
    void addMaterial(GameObject materialObject, Level level, Material material);
    void removeMaterial(GameObject gameObject, Material material);
    void clearCache();
}

public class MaterialSpawmerRepositoryImpl: MaterialSpawmerRepository {

    private MaterialSpawmerCache materialSpawmerCache = MaterialSpawmerCacheImpl.getInstance();

    public void addMaterial(
        GameObject materialObject, 
        Level level, 
        Material material
    ) => materialSpawmerCache.addMaterial(
        materialObject: materialObject,
        level: level,
        material: material
    );

    public Dictionary<Material, int> bringMissingMaterial(Level level) => materialSpawmerCache.bringMissingMaterial(level: level);

    public void clearCache() => materialSpawmerCache.destroyInstance();

    public List<GameObject> getAllListMaterial() => materialSpawmerCache.listAllMaterials();

    public GameObject getCurrentMaterialSpawmer() => materialSpawmerCache.currentSpawmerGenerator;

    public List<string> getListNumberMaterialsByLevel(Level level) => materialSpawmerCache.getListNumberMaterialsByLevel(level: level);

    public bool isAllMaterialsInLevel(Level level) => materialSpawmerCache.isAllMaterialsInLevel(level: level);

    public void removeMaterial(GameObject gameObject, Material material) => materialSpawmerCache.removeMaterial(gameObject: gameObject, material: material);

    public void setCurrentMaterialSpawmer(GameObject materialSpawmer) => materialSpawmerCache.currentSpawmerGenerator = materialSpawmer;
}