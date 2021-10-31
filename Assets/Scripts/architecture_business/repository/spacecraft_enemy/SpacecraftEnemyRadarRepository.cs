using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRadarRepository {
    List<GameObject> gameObjectsInRadar(IdentificatorModel identificatorModel);
    void addGameobjectToRadar(IdentificatorModel identificator, GameObject gameObject);
    RadarEnemy currentRada(IdentificatorModel identificator);
    bool loadRadar(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
    int radiusRadar(IdentificatorModel identificator);
    void removeRadar(IdentificatorModel identificator);
    void removeGameobjectFromRadar(IdentificatorModel identificator, GameObject gameObject);
}
public class SpacecraftEnemyRadarRepositoryImpl : SpacecraftEnemyRadarRepository
{
    private SpacecraftEnemyRadarCache cache = SpacecraftEnemyRadarCacheImpl.getInstance();

    public void addGameobjectToRadar(IdentificatorModel identificator, GameObject gameObject) => cache.addGameobjectToRadar(identificator, gameObject);

    public RadarEnemy currentRada(IdentificatorModel identificator) => cache.currentRada(identificator);

    public List<GameObject> gameObjectsInRadar(IdentificatorModel identificatorModel) => cache.gameObjectsInRadar(identificatorModel);

    public bool loadRadar(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => cache.loadRadar(identificator, spacecraft);

    public int radiusRadar(IdentificatorModel identificator) => cache.radiusRadar(identificator);

    public void removeGameobjectFromRadar(IdentificatorModel identificator, GameObject gameObject) => cache.removeObjectFromRadar(identificator, gameObject);

    public void removeRadar(IdentificatorModel identificator) => cache.removeRadar(identificator);
}