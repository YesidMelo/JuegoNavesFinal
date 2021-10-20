using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerCache {
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

public class SpacecraftPlayerCacheImpl : SpacecraftPlayerCache
{
    //static variables
    private static SpacecraftPlayerCacheImpl instance;

    //static methods
    public static SpacecraftPlayerCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftPlayerCacheImpl();
        }
        return instance;
    }

    //variables
    private List<LaserPlayer> _currentLasers = new List<LaserPlayer>();
    private StructurePlayer _currentStructure = StructurePlayer.TYPE_1;
    private List<MotorPlayer> _currentMotors = new List<MotorPlayer>();
    private RadarPlayer _currentRadar = RadarPlayer.TYPE_1;
    private StoragePlayer _currentStorage = StoragePlayer.TYPE_1;

    private SpacecraftPlayerCacheImpl() {
        _currentLasers.Add(LaserPlayer.TYPE_1);
        _currentMotors.Add(MotorPlayer.TYPE_1);
    }

    // gets
    public List<LaserPlayer> currentListLasers => _currentLasers;

    public StructurePlayer currentStructure => _currentStructure;

    public List<MotorPlayer> currentListMotors => _currentMotors;

    public RadarPlayer currentRadarPlayer => _currentRadar;

    public StoragePlayer currentStorage => _currentStorage;

    //sets

    public void updateCurrentLasers(List<LaserPlayer> lasers)
    {
        if (lasers.Count == 0) return;
        _currentLasers = lasers;
    }

    public void updateCurrentMotors(List<MotorPlayer> motors)
    {
        if (motors.Count == 0) return;
        _currentMotors = motors;
    }

    public void updateRadar(RadarPlayer radar) => _currentRadar = radar;

    public void updateStorage(StoragePlayer storage) => _currentStorage = storage;

    public void updateStructure(StructurePlayer structure) => _currentStructure = structure;

    public IEnumerator loadSpacecraft()
    {
        yield return new WaitForSeconds(5);
        yield return true;
    }
}