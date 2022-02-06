using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerRadarCache {

    List<GameObject> getListObjectsRadar { get; }
    RadarPlayer currentRadarPlayer { get; }
    RadarModel currentRadarModel { get; }

    float radiusRadar { get; }
    void addElementToRadar(GameObject gameObject);
    void clearElementsRadar();
    void removeElementFromRadar(GameObject gameObject);
    bool loadElementsRadar();
    void updateCurrentRadar(RadarPlayer radar);
    void setCurrentRadarModel(RadarModel radarModel);
    public void clearCache();

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

    public static void destroyInstance() => instance = null;

    private List<GameObject> _listElementsRadar = new List<GameObject>();
    private RadarModel radarModel = new RadarModel();
    

    private RadarPlayer _currentRadarPlayer = RadarPlayer.TYPE_1;
    private float _currentRadiusRadar = 1f;

    public List<GameObject> getListObjectsRadar => _listElementsRadar;

    public float radiusRadar => _currentRadiusRadar;

    public RadarPlayer currentRadarPlayer => _currentRadarPlayer;

    public RadarModel currentRadarModel => radarModel;

    public void addElementToRadar(GameObject gameObject)
    {
        if (_listElementsRadar.Contains(gameObject)) return;
        _listElementsRadar.Add(gameObject);
    }
    public void clearCache()
    {
        _listElementsRadar.Clear();
        radarModel = new RadarModel();
        _currentRadarPlayer = RadarPlayer.TYPE_1;
        _currentRadiusRadar = 1f;
    }

    public void clearElementsRadar()=> _listElementsRadar.Clear();

    public bool loadElementsRadar() {
        calculateRadiusRadar();
        return true; 
    }

    public void removeElementFromRadar(GameObject gameObject)
    {
        if (!_listElementsRadar.Contains(gameObject)) return;
        _listElementsRadar.Remove(gameObject);
    }

    public void updateCurrentRadar(RadarPlayer radar)
    {
        _currentRadarPlayer = radar;
        radarModel.currentRadarPlayer = radar;
        calculateRadiusRadar();
    }

    public void setCurrentRadarModel(RadarModel radarModel)
    {
        this.radarModel = radarModel;
        _currentRadarPlayer = radarModel.currentRadarPlayer;
        calculateRadiusRadar();
    }

    //private methods
    private void calculateRadiusRadar() {
        switch (_currentRadarPlayer) {
            case RadarPlayer.TYPE_2:
                _currentRadiusRadar = Constants.radarPlayerRadiusRadarType2;
                return;
            case RadarPlayer.TYPE_3:
                _currentRadiusRadar = Constants.radarPlayerRadiusRadarType3;
                return;
            case RadarPlayer.TYPE_4:
                _currentRadiusRadar = Constants.radarPlayerRadiusRadarType4;
                return;
            case RadarPlayer.TYPE_5:
                _currentRadiusRadar = Constants.radarPlayerRadiusRadarType5;
                return;
            case RadarPlayer.TYPE_1:
            default:
                _currentRadiusRadar = Constants.radarPlayerRadiusRadarType1;
                return;
        }
    }

}
