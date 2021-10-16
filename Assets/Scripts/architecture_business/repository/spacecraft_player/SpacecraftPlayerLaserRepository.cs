using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLaserRepository {

    public List<LaserPlayer> listLasers { get; }
    public int mediaImpactLaser { get; }
    public LaserPlayer finalLaser { get; }

    public bool loadLasers();
    public void setListLaser(List<LaserPlayer> listLasers);
}

public class SpacecraftPlayerLaserRepositoryImpl : SpacecraftPlayerLaserRepository {

    private SpacecraftPlayerLaserCache cache = SpacecraftPlayerLaserCacheImpl.getInstance();

    public List<LaserPlayer> listLasers => cache.listLasers;
    public int mediaImpactLaser => cache.mediaImpactLaser;
    public LaserPlayer finalLaser => cache.finalImpactLaser;

    public bool loadLasers() => cache.loadLasers();    

    public void setListLaser(List<LaserPlayer> listLasers) => cache.setListLasers(listLasers);
}