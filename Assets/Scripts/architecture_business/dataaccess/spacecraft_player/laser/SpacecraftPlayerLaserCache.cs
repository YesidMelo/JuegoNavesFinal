using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLaserCache {

    public int mediaImpactLaser { get; }
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
    private int _mediaImpactLaser = 1;
    private LaserPlayer _finalImpactLaser = LaserPlayer.TYPE_1;

    public SpacecraftPlayerLaserCacheImpl() {}

    public List<LaserPlayer> listLasers => _listLasers;

    public int mediaImpactLaser => _mediaImpactLaser;

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
        _mediaImpactLaser = calculateMediaImpactLaser();
        _finalImpactLaser = calculateFinalImpactLaser();
    }

    //private methods

    int calculateMediaImpactLaser()
    {
        int finalMediaImpactLaser = 0;
        for (int index = 0; index < _listLasers.Count; index++)
        {
            finalMediaImpactLaser = finalMediaImpactLaser + getImpactLaserFromType(_listLasers[index]);
        }

        return finalMediaImpactLaser / _listLasers.Count;
    }

    int getImpactLaserFromType(LaserPlayer laser)
    {
        switch (laser)
        {
            case LaserPlayer.TYPE_2:
                return (int)Constants.laserPlayerType2;
            case LaserPlayer.TYPE_3:
                return (int)Constants.laserPlayerType3;
            case LaserPlayer.TYPE_4:
                return (int)Constants.laserPlayerType4;
            case LaserPlayer.TYPE_5:
                return (int)Constants.laserPlayerType5;
            case LaserPlayer.TYPE_1:
            default:
                return (int)Constants.laserPlayerType1;
        }
    }

    LaserPlayer calculateFinalImpactLaser()
    {
        if (_mediaImpactLaser > 0 && _mediaImpactLaser < Constants.laserPlayerType2) return LaserPlayer.TYPE_1;
        if (Constants.laserPlayerType2 <= _mediaImpactLaser && _mediaImpactLaser < Constants.laserPlayerType3) return LaserPlayer.TYPE_2;
        if (Constants.laserPlayerType3 <= _mediaImpactLaser && _mediaImpactLaser < Constants.laserPlayerType4) return LaserPlayer.TYPE_3;
        if (Constants.laserPlayerType4 <= _mediaImpactLaser && _mediaImpactLaser < Constants.laserPlayerType5) return LaserPlayer.TYPE_4;
        return LaserPlayer.TYPE_5;
    }

    
}
