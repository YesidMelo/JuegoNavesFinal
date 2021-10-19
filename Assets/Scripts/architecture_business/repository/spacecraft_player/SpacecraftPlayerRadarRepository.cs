using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerRadarRepository {
    List<GameObject> getListObjectsRadar { get; }
    RadarPlayer currentRadarPlayer { get; }
    float currentRadiusRadar { get; }
    void addElementToRadar(GameObject gameObject);
    void removeElementFromRadar(GameObject gameObject);
    bool loadElementsRadar();
    void clearElementsRadar();
    void updateCurrentRadarPlayer(RadarPlayer radarPlayer);
}

public class SpacecraftPlayerRadarRepositoryImpl : SpacecraftPlayerRadarRepository
{
    private SpacecraftPlayerRadarCache cache = SpacecraftPlayerRadarCacheImpl.getInstance();

    public List<GameObject> getListObjectsRadar => cache.getListObjectsRadar;

    public RadarPlayer currentRadarPlayer => cache.currentRadarPlayer;

    public float currentRadiusRadar => cache.radiusRadar;

    public void addElementToRadar(GameObject gameObject) => cache.addElementToRadar(gameObject);

    public void clearElementsRadar() => cache.clearElementsRadar();

    public bool loadElementsRadar() => cache.loadElementsRadar();

    public void removeElementFromRadar(GameObject gameObject) => cache.removeElementFromRadar(gameObject);

    public void updateCurrentRadarPlayer(RadarPlayer radarPlayer) => cache.updateCurrentRadar(radarPlayer);
}