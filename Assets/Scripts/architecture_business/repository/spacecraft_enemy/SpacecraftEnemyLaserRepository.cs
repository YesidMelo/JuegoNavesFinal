using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLaserRepository {
    public void deleteLaser(IdentificatorModel identificatorModel);
    public Laser finalImpactLaser(IdentificatorModel identificatorModel);
    public List<Laser> listLasers(IdentificatorModel identificatorModel);
    public int mediaImpactLaser(IdentificatorModel identificatorModel);
    public void setListLasers(List<Laser> listLasers, IdentificatorModel identificatorModel);
}
public class SpacecraftEnemyLaserRepositoryImpl : SpacecraftEnemyLaserRepository
{

    private SpacecraftEnemyLaserCache cache = SpacecraftEnemyLaserCacheImpl.getInstance();

    public void deleteLaser(IdentificatorModel identificatorModel) => cache.deleteLaser(identificatorModel);

    public Laser finalImpactLaser(IdentificatorModel identificatorModel) => cache.finalImpactLaser(identificatorModel);

    public List<Laser> listLasers(IdentificatorModel identificatorModel) => cache.listLasers(identificatorModel);

    public int mediaImpactLaser(IdentificatorModel identificatorModel) => cache.mediaImpactLaser(identificatorModel);

    public void setListLasers(List<Laser> listLasers, IdentificatorModel identificatorModel) => cache.setListLasers(listLasers, identificatorModel);
}