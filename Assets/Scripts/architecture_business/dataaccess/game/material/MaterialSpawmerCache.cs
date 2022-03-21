using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerCache {
    GameObject currentSpawmerGenerator { get; set; }
    List<GameObject> listAllMaterials();
    List<string> getListNumberMaterialsByLevel(Level level);

    bool isAllMaterialsInLevel(Level level);
    void addMaterial(GameObject materialObject, Level level, Material material);
    void removeMaterial(GameObject gameObject, Level level, Material material);
    void destroyInstance();
}

public class MaterialSpawmerCacheImpl: MaterialSpawmerCache {

    //static varialbles
    private static MaterialSpawmerCache instance;

    //static methods
    public static MaterialSpawmerCache getInstance() {
        if (instance == null) {
            instance = new MaterialSpawmerCacheImpl();
        }
        return instance;
    }

    //variables
    private readonly List<MaterialSpawmer1Model> _listSpawmerModel = new List<MaterialSpawmer1Model>();
    private readonly List<GameObject> _listAllMaterials = new List<GameObject>();
    private GameObject _currentMaterialSpawmer;

    public GameObject currentSpawmerGenerator {
        get => _currentMaterialSpawmer;
        set => _currentMaterialSpawmer = value; 
    }

    private MaterialSpawmerCacheImpl() {
        initMaterials();
    }

    //public methods
    public void addMaterial(GameObject materialObject, Level level, Material material)
    {
        MaterialSpawmer1Model materialSpawmer = getFilterMaterialByLevel(level: level);

        if (materialSpawmer == null) return;
        if (isAllMaterialSpawmer1Model(materialSpawmer: materialSpawmer, material: material)) return;
        if (materialSpawmer.dictionaryGameObjects[material].Contains(materialObject)) return;

        materialSpawmer.dictionaryGameObjects[material].Add(materialObject);
        materialSpawmer.counterMaterialsInLevel[material] = materialSpawmer.dictionaryGameObjects[material].Count;
        _listAllMaterials.Add(materialObject);
        isAllMaterialSpawmer1Model(materialSpawmer: materialSpawmer, material: material);

    }

    public void destroyInstance() => instance = null;

    public void removeMaterial(GameObject gameObject, Level level, Material material)
    {
        MaterialSpawmer1Model materialSpawmer = getFilterMaterialByLevel(level: level);

        if (materialSpawmer == null) return;
        
        if (!materialSpawmer.dictionaryGameObjects[material].Contains(gameObject)) return;

        materialSpawmer.dictionaryGameObjects[material].Remove(gameObject);
        materialSpawmer.counterMaterialsInLevel[material] = materialSpawmer.dictionaryGameObjects[material].Count;
        _listAllMaterials.Remove(gameObject);
        isAllMaterialSpawmer1Model(materialSpawmer: materialSpawmer, material: material);
        
    }

    public List<GameObject> listAllMaterials() => _listAllMaterials;

    public bool isAllMaterialsInLevel(Level level) {
        bool isAllMAterial = true;
        MaterialSpawmer1Model materialSpawmer = getFilterMaterialByLevel(level: level);
        if (materialSpawmer == null) return false;

        foreach (Material currentMaterial in Enum.GetValues(typeof(Material))) {
            if (isAllMaterialSpawmer1Model(materialSpawmer: materialSpawmer, material: currentMaterial)) continue;
            return false;
        }
        
        return isAllMAterial;
    }

    public List<string> getListNumberMaterialsByLevel(Level level) {
        
        List<string> listMaterials = new List<string>();
        MaterialSpawmer1Model materialSpawmerModel = getFilterMaterialByLevel(level: level);
        if (materialSpawmerModel == null) return listMaterials;

        foreach (KeyValuePair<Material, int> current in materialSpawmerModel.counterMaterialsInLevel) {
            listMaterials.Add($"{current.Key} = ${current.Value}");
        }

        return listMaterials;
    }

    //private methods
    private bool isAllMaterialSpawmer1Model(MaterialSpawmer1Model materialSpawmer, Material material) {
        int maxMaterial = materialSpawmer.level.getMaxMaterial(material: material);
        int currentMaterials = materialSpawmer.counterMaterialsInLevel[material];
        return currentMaterials >= maxMaterial;
    }

    private void initMaterials() {
        foreach (Level currentLevel in Enum.GetValues(typeof(Level))) {
            MaterialSpawmer1Model model = new MaterialSpawmer1Model();
            model.level = currentLevel;

            foreach (Material currentMaterial in Enum.GetValues(typeof(Material))) {
                model.dictionaryGameObjects[currentMaterial] = new List<GameObject>();
                model.counterMaterialsInLevel[currentMaterial] = 0;
            }

            _listSpawmerModel.Add(model);
        }
    }

    private MaterialSpawmer1Model getFilterMaterialByLevel(Level level) {
        foreach (MaterialSpawmer1Model current in _listSpawmerModel) {
            if (current.level != level) continue;
            return current;
        }
        return null;
    }

}