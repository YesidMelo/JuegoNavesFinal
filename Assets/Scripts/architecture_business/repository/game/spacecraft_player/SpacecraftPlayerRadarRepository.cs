using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerRadarRepository {
    #region generic
    List<GameObject> getListObjectsRadar { get; }
    RadarModel currentRadarModel { get; }
    RadarPlayer currentRadarPlayer { get; }
    float currentRadiusRadar { get; }
    void addElementToRadar(GameObject gameObject);
    void removeElementFromRadar(GameObject gameObject);
    bool loadElementsRadar();
    void clearElementsRadar();
    void updateCurrentRadarPlayer(RadarPlayer radarPlayer);
    void setCurrentRadarModel(RadarModel radarModel);
    public void clearCache();
    #endregion

    #region enemies
    List<GameObject> getListEnemies { get; }
    GameObject currentEnemy { get; }
    void changeCurrentEnemy();
    #endregion

    #region materials
    List<GameObject> listMaterials { get; }
    GameObject currentMaterial { get; }
    void addMaterial(GameObject material);
    void removeMaterial(GameObject material);
    void changeMaterial();
    #endregion

}

public class SpacecraftPlayerRadarRepositoryImpl : SpacecraftPlayerRadarRepository
{
    private readonly SpacecraftPlayerRadarCache cache = SpacecraftPlayerRadarCacheImpl.getInstance();
    private readonly SpacecraftPlayerRadarEnemiesCache cacheEnemies = SpacecraftPlayerRadarEnemiesCacheImpl.getInstance();
    private readonly SpacecraftPlayerRadarMaterialCache cacheMaterials = SpacecraftPlayerRadarMaterialCacheImpl.getInstance();

    #region generic
    public List<GameObject> getListObjectsRadar => cache.getListObjectsRadar;
    public RadarPlayer currentRadarPlayer => cache.currentRadarPlayer;
    public float currentRadiusRadar => cache.radiusRadar;
    public RadarModel currentRadarModel => cache.currentRadarModel;
    public void addElementToRadar(GameObject gameObject) { 
        cache.addElementToRadar(gameObject);
        cacheEnemies.addEnemy(gameObject);
    }
    public void clearCache() => cache.clearCache();
    public void clearElementsRadar() {
        SpacecraftPlayerRadarCacheImpl.destroyInstance();
        SpacecraftPlayerRadarEnemiesCacheImpl.destroyInstance();
    }
    public bool loadElementsRadar() => cache.loadElementsRadar();
    public void removeElementFromRadar(GameObject gameObject) {
        cache.removeElementFromRadar(gameObject);
        cacheEnemies.removeEnemy(gameObject);
    }
    public void setCurrentRadarModel(RadarModel radarModel) => cache.setCurrentRadarModel(radarModel: radarModel);
    public void updateCurrentRadarPlayer(RadarPlayer radarPlayer) => cache.updateCurrentRadar(radarPlayer);
    #endregion

    #region enemies
    public List<GameObject> getListEnemies => cacheEnemies.listEnemies;
    public GameObject currentEnemy => cacheEnemies.currentEnemy;

    public void changeCurrentEnemy() => cacheEnemies.changeEnemy();
    #endregion

    #region materials
    public List<GameObject> listMaterials => cacheMaterials.listMaterials;

    public GameObject currentMaterial => cacheMaterials.currentMaterial;

    public void addMaterial(GameObject material) => cacheMaterials.addMaterial(material: material);

    public void removeMaterial(GameObject material) => cacheMaterials.removeMaterial(material: material);

    public void changeMaterial() => cacheMaterials.changeMaterial();
    #endregion
}