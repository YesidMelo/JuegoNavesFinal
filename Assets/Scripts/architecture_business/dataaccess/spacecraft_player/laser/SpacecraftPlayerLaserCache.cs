using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLaserCache {

    public int mediaImpactLaser { get; }
    public List<Laser> listLasers { get; }
    public Laser finalImpactLaser { get; }
    public void setListLasers(List<Laser> listLasers);

}

public class SpacecraftPlayerLaserCacheImpl : SpacecraftPlayerLaserCache {

    private static SpacecraftPlayerLaserCacheImpl _instance;

    public static SpacecraftPlayerLaserCacheImpl getInstance() {
        if (_instance == null) {
            _instance = new SpacecraftPlayerLaserCacheImpl();
        }
        return _instance;
    }

    private List<Laser> _listLasers = new List<Laser>();
    private int _mediaImpactLaser = 1;
    private Laser _finalImpactLaser = Laser.TYPE_1;

    public SpacecraftPlayerLaserCacheImpl() {
        _listLasers.Add(Laser.TYPE_1);
    }

    public List<Laser> listLasers => _listLasers;

    public int mediaImpactLaser => _mediaImpactLaser;

    public Laser finalImpactLaser => _finalImpactLaser;


    public void setListLasers(List<Laser> listLasers)
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

    int getImpactLaserFromType(Laser laser)
    {
        switch (laser)
        {
            case Laser.TYPE_2:
                return (int)Constants.laserType2;
            case Laser.TYPE_3:
                return (int)Constants.laserType3;
            case Laser.TYPE_4:
                return (int)Constants.laserType4;
            case Laser.TYPE_5:
                return (int)Constants.laserType5;
            case Laser.TYPE_1:
            default:
                return (int)Constants.laserType1;
        }
    }

    Laser calculateFinalImpactLaser()
    {
        if (_mediaImpactLaser > 0 && _mediaImpactLaser < Constants.laserType2) return Laser.TYPE_1;
        if (Constants.laserType2 <= _mediaImpactLaser && _mediaImpactLaser < Constants.laserType3) return Laser.TYPE_2;
        if (Constants.laserType3 <= _mediaImpactLaser && _mediaImpactLaser < Constants.laserType4) return Laser.TYPE_3;
        if (Constants.laserType4 <= _mediaImpactLaser && _mediaImpactLaser < Constants.laserType5) return Laser.TYPE_4;
        return Laser.TYPE_5;
    }

}
