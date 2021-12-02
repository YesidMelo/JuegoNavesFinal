using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerRadarEnemiesCache { 
    List<GameObject> listEnemies { get; }
    GameObject currentEnemy { get; }

    void addEnemy(GameObject gameObject);
    void removeEnemy(GameObject gameObject);
    void changeEnemy();
}

public class SpacecraftPlayerRadarEnemiesCacheImpl : SpacecraftPlayerRadarEnemiesCache {

    // static variables
    private static SpacecraftPlayerRadarEnemiesCacheImpl instance;

    // static methods
    public static SpacecraftPlayerRadarEnemiesCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftPlayerRadarEnemiesCacheImpl();
        }
        return instance;
    }

    private List<GameObject> _listEnemies = new List<GameObject>();
    private GameObject _currentEnemy = null;

    public List<GameObject> listEnemies => _listEnemies;
    public GameObject currentEnemy => _currentEnemy;

    public void addEnemy(GameObject gameObject)
    {
        if (!gameObject.name.Contains(Constants.nameShieldEnemy)) return;
        if (_listEnemies.Contains(gameObject)) return;
        _listEnemies.Add(gameObject);
    }

    public void removeEnemy(GameObject gameObject)
    {
        if (!gameObject.name.Contains(Constants.nameShieldEnemy)) return;
        if (!_listEnemies.Contains(gameObject)) return;
        _listEnemies.Remove(gameObject);
    }

    public void changeEnemy() {
        if (isEmptyList()) return;
        if (isCheckUniqueEnemy()) return;
        changeEnemyWithListMajorTwoElements();
    }

    // private methods
    private bool isEmptyList() {
        if (_listEnemies.Count != 0) return false;
        if (_currentEnemy != null) {
            _currentEnemy = null;
        }
        return true;
    }

    private bool isCheckUniqueEnemy() {
        if (listEnemies.Count != 1) return false;
        _currentEnemy = _listEnemies[0];
        return true;
    }

    private void changeEnemyWithListMajorTwoElements()
    {
        GameObject objectRemoved = _listEnemies[0];
        _listEnemies.Remove(objectRemoved);
        _currentEnemy = _listEnemies[0];
        _listEnemies.Add(objectRemoved);
    }

}