using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerRepository {
    public List<LaserPlayer> currentListLasers { get; }
    public List<MotorPlayer> currentListMotors { get; }
    RadarPlayer currentRadarPlayer { get; }
    StoragePlayer currentStorage { get; }
    public StructurePlayer currentStructure { get; }

    void updateCurrentLasers(List<LaserPlayer> lasers);
    void updateCurrentMotors(List<MotorPlayer> motors);
    void updateRadar(RadarPlayer radar);
    void updateStorage(StoragePlayer storage);
    void updateStructure(StructurePlayer structure);
    IEnumerator loadSpacecraft();
}

public class SpacecraftPlayerRepositoryImpl : SpacecraftPlayerRepository
{
    private SpacecraftPlayerCache cache = SpacecraftPlayerCacheImpl.getInstance();

    public List<LaserPlayer> currentListLasers => cache.currentListLasers;

    public List<MotorPlayer> currentListMotors => cache.currentListMotors;

    public RadarPlayer currentRadarPlayer => cache.currentRadarPlayer;

    public StoragePlayer currentStorage => cache.currentStorage;

    public StructurePlayer currentStructure => cache.currentStructure;

    public IEnumerator loadSpacecraft() => cache.loadSpacecraft();

    public void updateCurrentLasers(List<LaserPlayer> lasers) => cache.updateCurrentLasers(lasers);
    public void updateCurrentMotors(List<MotorPlayer> motors) => cache.updateCurrentMotors(motors);
    public void updateRadar(RadarPlayer radar) => cache.updateRadar(radar);
    public void updateStorage(StoragePlayer storage) => cache.updateStorage(storage);
    public void updateStructure(StructurePlayer structure) => cache.updateStructure(structure);
}