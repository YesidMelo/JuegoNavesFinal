using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLaserRepository {
    public void deleteLaser(IdentificatorModel identificatorModel);
    public LaserEnemy finalImpactLaser(IdentificatorModel identificatorModel);
    public List<LaserEnemy> listLasers(IdentificatorModel identificatorModel);
    public int mediaImpactLaser(IdentificatorModel identificatorModel);
    public void setListLasers(List<LaserEnemy> listLasers, IdentificatorModel identificatorModel);
    public bool loadListLasers(IdentificatorModel identificator);
}
public class SpacecraftEnemyLaserRepositoryImpl : SpacecraftEnemyLaserRepository
{

    private SpacecraftEnemyLaserCache cache = SpacecraftEnemyLaserCacheImpl.getInstance();

    public void deleteLaser(IdentificatorModel identificatorModel) => cache.deleteLaser(identificatorModel);

    public LaserEnemy finalImpactLaser(IdentificatorModel identificatorModel) => cache.finalImpactLaser(identificatorModel);

    public List<LaserEnemy> listLasers(IdentificatorModel identificatorModel) => cache.listLasers(identificatorModel);

    public bool loadListLasers(IdentificatorModel identificator) => cache.loadLasers(identificator);

    public int mediaImpactLaser(IdentificatorModel identificatorModel) => cache.mediaImpactLaser(identificatorModel);

    public void setListLasers(List<LaserEnemy> listLasers, IdentificatorModel identificatorModel) => cache.setListLasers(listLasers, identificatorModel);
}