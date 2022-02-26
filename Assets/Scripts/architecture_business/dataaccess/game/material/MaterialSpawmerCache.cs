using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerCache {
    GameObject currentSpawmerGenerator { get; set; }
    List<GameObject> listAllMaterials();
    bool isAllMaterialsInLevel();
    bool addMaterial(GameObject materialObject, Level level, Material material);
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
    private List<MaterialSpawmer1Model> _listSpawmerModel = new List<MaterialSpawmer1Model>();
    private List<GameObject> _listAllMaterials = new List<GameObject>();
    private GameObject _currentMaterialSpawmer;
    private bool isAllMaterials = false;

    public GameObject currentSpawmerGenerator {
        get => _currentMaterialSpawmer;
        set => _currentMaterialSpawmer = value; 
    }

    private MaterialSpawmerCacheImpl() {
        initMaterials();
    }

    //public methods
    public bool addMaterial(GameObject materialObject, Level level, Material material)
    {
        if (isAllMaterials) return true;

        MaterialSpawmer1Model materialSpawmerModel = getFilterMaterialByLevel(level: level);
        if (materialSpawmerModel == null) return true;
        if (materialSpawmerModel.dictionaryGameObjects[material].Contains(materialObject)) return true;

        materialSpawmerModel.dictionaryGameObjects[material].Add(materialObject);
        materialSpawmerModel.counterMaterialsInLevel[material] = materialSpawmerModel.dictionaryGameObjects[material].Count;
        loadAllGameObjects();
        _isAllMaterialsInLevel(level: level);
        return true;
    }

    public void destroyInstance() => instance = null;

    public void removeMaterial(GameObject gameObject, Level level, Material material)
    {
        MaterialSpawmer1Model materialSpawmerModel = getFilterMaterialByLevel(level: level);
        if (materialSpawmerModel == null) return;
        if (!materialSpawmerModel.dictionaryGameObjects[material].Contains(gameObject)) return;

        materialSpawmerModel.dictionaryGameObjects[material].Remove(gameObject);
        materialSpawmerModel.counterMaterialsInLevel[material] = materialSpawmerModel.dictionaryGameObjects[material].Count;
        loadAllGameObjects();
    }

    public List<GameObject> listAllMaterials() => _listAllMaterials;

    public bool isAllMaterialsInLevel() => isAllMaterials;

    //private methods

    private void loadAllGameObjects() {
        _listAllMaterials = new List<GameObject>();
        foreach(MaterialSpawmer1Model currentSpawmerModel in _listSpawmerModel) {
            foreach (Material currentMaterial in Enum.GetValues(typeof(Material))) {

                List<GameObject> listMaterial = currentSpawmerModel.dictionaryGameObjects[currentMaterial];
                if (listMaterial.Count == 0) continue;

                foreach (GameObject currentGameObject in listMaterial) {
                    _listAllMaterials.Add(currentGameObject);
                }
            }
        }
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
        foreach (MaterialSpawmer1Model currentSpawmer in _listSpawmerModel) {
            if (currentSpawmer.level == level) continue;
            return currentSpawmer;
        }
        return null;
    }

    private void _isAllMaterialsInLevel(Level level) {
        MaterialSpawmer1Model materialSpawmer1Model = getFilterMaterialByLevel(level: level);
        foreach (Material currentMaterial in Enum.GetValues(typeof(Material))) {
            int currentValueMaterial = materialSpawmer1Model.counterMaterialsInLevel[currentMaterial];

            if (currentValueMaterial >= level.getMaxMaterial(material: currentMaterial)) continue;
            isAllMaterials = false;
            return;
        }
        isAllMaterials = true;
    }

    
}