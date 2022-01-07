using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLaserCache {

    public float mediaImpactLaser { get; }
    public List<LaserPlayer> listLasers { get; }
    public LaserModel currentLaserModel { get; }
    public LaserPlayer finalImpactLaser { get; }
    public bool loadLasers();
    public void setCurrentLaserModel(LaserModel laserModel);
    public void setListLasers(List<LaserPlayer> listLasers);
}

public class SpacecraftPlayerLaserCacheImpl : SpacecraftPlayerLaserCache {

    private static SpacecraftPlayerLaserCacheImpl _instance;

    public static SpacecraftPlayerLaserCacheImpl getInstance() {
        if (_instance == null) {
            _instance = new SpacecraftPlayerLaserCacheImpl();
        }
        return _instance;
    }

    private List<LaserPlayer> _listLasers = new List<LaserPlayer>();
    private float _mediaImpactLaser = 1;
    private LaserPlayer _finalImpactLaser = LaserPlayer.TYPE_1;
    private LaserModel _currrentLaserModel = new LaserModel();

    public SpacecraftPlayerLaserCacheImpl() {}

    public List<LaserPlayer> listLasers => _listLasers;

    public float mediaImpactLaser => _mediaImpactLaser;

    public LaserPlayer finalImpactLaser => _finalImpactLaser;

    public LaserModel currentLaserModel => _currrentLaserModel;

    public bool loadLasers()
    {
        if (listLasers.Count != 0) return true;
        _listLasers.Add(LaserPlayer.TYPE_1);
        setListLasers(_listLasers);
        return true;
    }

    public void setListLasers(List<LaserPlayer> listLasers)
    {
        if (listLasers.Count == 0) return;
        _listLasers = listLasers;
        _currrentLaserModel.listLasers = listLasers;
        _mediaImpactLaser = calculatefinalImpact();
        _finalImpactLaser = calculateFinalImpactLaser();
    }

    public void setCurrentLaserModel(LaserModel laserModel) => _currrentLaserModel = laserModel;
   
    //private methods

    float calculatefinalImpact()
    {
        float finalMediaImpactLaser = 0;
        for (int index = 0; index < _listLasers.Count; index++)
        {
            finalMediaImpactLaser = finalMediaImpactLaser + _listLasers[index].getCurrentImpact();
        }

        return finalMediaImpactLaser;
    }  

    LaserPlayer calculateFinalImpactLaser() => _listLasers.getCurrentLaserPlayer();

}
