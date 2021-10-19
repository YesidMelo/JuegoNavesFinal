using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerRadarCache {

    List<GameObject> getListObjectsRadar { get; }
    void addElementToRadar(GameObject gameObject);
    void removeElementFromRadar(GameObject gameObject);
    bool loadElementsRadar();
    void clearElementsRadar();
}

public class SpacecraftPlayerRadarCacheImpl : SpacecraftPlayerRadarCache
{
    //static variables
    private static SpacecraftPlayerRadarCacheImpl instance;

    //static methods
    public static SpacecraftPlayerRadarCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftPlayerRadarCacheImpl();
        }
        return instance;
    }

    private List<GameObject> _listElementsRadar = new List<GameObject>();

    public List<GameObject> getListObjectsRadar => _listElementsRadar;

    public void addElementToRadar(GameObject gameObject)
    {
        if (_listElementsRadar.Contains(gameObject)) return;
        _listElementsRadar.Add(gameObject);
    }

    public void clearElementsRadar()=> _listElementsRadar.Clear();

    public bool loadElementsRadar() => true;

    public void removeElementFromRadar(GameObject gameObject)
    {
        if (!_listElementsRadar.Contains(gameObject)) return;
        _listElementsRadar.Remove(gameObject);
    }
}
