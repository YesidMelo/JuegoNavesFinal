using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerRadarRepository {
    List<GameObject> getListObjectsRadar { get; }
    List<GameObject> getListEnemies { get; }
    RadarPlayer currentRadarPlayer { get; }
    RadarModel currentRadarModel { get; }
    GameObject currentEnemy { get; }
    float currentRadiusRadar { get; }
    void addElementToRadar(GameObject gameObject);
    void removeElementFromRadar(GameObject gameObject);
    bool loadElementsRadar();
    void clearElementsRadar();
    void updateCurrentRadarPlayer(RadarPlayer radarPlayer);
    void changeCurrentEnemy();
    void setCurrentRadarModel(RadarModel radarModel);
    public void clearCache();
}

public class SpacecraftPlayerRadarRepositoryImpl : SpacecraftPlayerRadarRepository
{
    private SpacecraftPlayerRadarCache cache = SpacecraftPlayerRadarCacheImpl.getInstance();
    private SpacecraftPlayerRadarEnemiesCache cacheEnemies = SpacecraftPlayerRadarEnemiesCacheImpl.getInstance();

    public List<GameObject> getListObjectsRadar => cache.getListObjectsRadar;

    public RadarPlayer currentRadarPlayer => cache.currentRadarPlayer;

    public float currentRadiusRadar => cache.radiusRadar;

    public List<GameObject> getListEnemies => cacheEnemies.listEnemies;

    public GameObject currentEnemy => cacheEnemies.currentEnemy;

    public RadarModel currentRadarModel => cache.currentRadarModel;

    public void addElementToRadar(GameObject gameObject) { 
        cache.addElementToRadar(gameObject);
        cacheEnemies.addEnemy(gameObject);
    }

    public void changeCurrentEnemy() => cacheEnemies.changeEnemy();

    public void clearCache() => cache.clearCache();

    public void clearElementsRadar() => cache.clearElementsRadar();

    public bool loadElementsRadar() => cache.loadElementsRadar();

    public void removeElementFromRadar(GameObject gameObject) {
        cache.removeElementFromRadar(gameObject);
        cacheEnemies.removeEnemy(gameObject);
    }

    public void setCurrentRadarModel(RadarModel radarModel) => cache.setCurrentRadarModel(radarModel: radarModel);
    public void updateCurrentRadarPlayer(RadarPlayer radarPlayer) => cache.updateCurrentRadar(radarPlayer);
}