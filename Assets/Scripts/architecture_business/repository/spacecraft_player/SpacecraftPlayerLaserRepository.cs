using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLaserRepository {

    public List<Laser> listLasers { get; }
    public int mediaImpactLaser { get; }
    public Laser finalLaser { get; }
    public void setListLaser(List<Laser> listLasers);
}

public class SpacecraftPlayerLaserRepositoryImpl : SpacecraftPlayerLaserRepository {

    private SpacecraftPlayerLaserCache cache = SpacecraftPlayerLaserCacheImpl.getInstance();

    public List<Laser> listLasers => cache.listLasers;
    public int mediaImpactLaser => cache.mediaImpactLaser;
    public Laser finalLaser => cache.finalImpactLaser;
    public void setListLaser(List<Laser> listLasers) => cache.setListLasers(listLasers);
}