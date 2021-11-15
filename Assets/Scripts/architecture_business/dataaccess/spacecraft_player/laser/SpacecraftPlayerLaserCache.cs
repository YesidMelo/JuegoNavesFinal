using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLaserCache {

    public float mediaImpactLaser { get; }
    public List<LaserPlayer> listLasers { get; }
    public LaserPlayer finalImpactLaser { get; }
    public bool loadLasers();
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

    public SpacecraftPlayerLaserCacheImpl() {}

    public List<LaserPlayer> listLasers => _listLasers;

    public float mediaImpactLaser => _mediaImpactLaser;

    public LaserPlayer finalImpactLaser => _finalImpactLaser;

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
        _mediaImpactLaser = calculatefinalImpact();
        _finalImpactLaser = calculateFinalImpactLaser();
    }

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
