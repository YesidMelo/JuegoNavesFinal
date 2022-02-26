using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerCache {
    GameObject currentSpawmerGenerator { get; set; }
    List<GameObject> listAllMaterials();
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
    private List<MaterialSpawmer1Model> _listSpawmerModel = new List<MaterialSpawmer1Model>();
    private List<GameObject> _listAllMaterials = new List<GameObject>();
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
        MaterialSpawmer1Model materialSpawmerModel = getFilterMaterialByLevel(level: level);
        if (materialSpawmerModel == null) return;
        if (materialSpawmerModel.dictionaryGameObjects[material].Contains(materialObject)) return;

        materialSpawmerModel.dictionaryGameObjects[material].Add(materialObject);
        materialSpawmerModel.counterMaterialsInLevel[material] = materialSpawmerModel.dictionaryGameObjects[material].Count;
        loadAllGameObjects();
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

}