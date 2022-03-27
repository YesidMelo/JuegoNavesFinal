using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerRadarMaterialCache { 
    List<GameObject> listMaterials { get; }
    GameObject currentMaterial { get; }
    void addMaterial(GameObject material);
    void removeMaterial(GameObject material);
    void changeMaterial();
}

public class SpacecraftPlayerRadarMaterialCacheImpl : SpacecraftPlayerRadarMaterialCache
{
    //static variables
    private static SpacecraftPlayerRadarMaterialCache instance;

    //static methods
    public static SpacecraftPlayerRadarMaterialCache getInstance() {
        if (instance == null) {
            instance = new SpacecraftPlayerRadarMaterialCacheImpl();
        }
        return instance;
    }

    private readonly List<GameObject> _listMaterials = new List<GameObject>();
    private GameObject _currentMaterial = null;

    public List<GameObject> listMaterials => _listMaterials;

    public GameObject currentMaterial => _currentMaterial;

    public void addMaterial(GameObject material)
    {
        if (!material.name.Contains(Constants.nameMaterial)) return;
        if (listMaterials.Contains(material)) return;
        listMaterials.Add(material);
    }

    public void changeMaterial()
    {
        if (isEmpty()) return;
        if (isUniqueElement()) return;
        changeEnemyWithListMajorTwoElements();
    }

    public void removeMaterial(GameObject material)
    {
        if (!material.name.Contains(Constants.nameMaterial)) return;
        if (!listMaterials.Contains(material)) return;
        listMaterials.Remove(material);
    }

    //private method
    private bool isEmpty() {
        if (listMaterials.Count != 0) return false;
        if (_currentMaterial != null) {
            _currentMaterial = null;
        }
        return true;
    }

    private bool isUniqueElement() {
        if (listMaterials.Count != 1) return false;
        _currentMaterial = listMaterials[0];
        return true;
    }

    private void changeEnemyWithListMajorTwoElements() {
        GameObject materialToRemove = _listMaterials[0];
        _listMaterials.Remove(materialToRemove);
        _currentMaterial = listMaterials[0];
        _listMaterials.Add(materialToRemove);
    }
}