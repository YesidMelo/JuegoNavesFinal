using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRadarRepository {
    List<GameObject> gameObjectsInRadar(IdentificatorModel identificatorModel);
    List<GameObject> getListPlayers(IdentificatorModel identificator);
    GameObject currentPlayer(IdentificatorModel identificator);
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
    private SpacecraftEnemyRadarPlayerCache cachePlayer = SpacecraftEnemyRadarPlayerCacheImpl.getInstance();

    public void addGameobjectToRadar(IdentificatorModel identificator, GameObject gameObject) { 
        cache.addGameobjectToRadar(identificator, gameObject);
        cachePlayer.addPlayer(identificator, gameObject);
    }

    public GameObject currentPlayer(IdentificatorModel identificator) => cachePlayer.currentPlayer(identificator);

    public RadarEnemy currentRada(IdentificatorModel identificator) => cache.currentRada(identificator);

    public List<GameObject> gameObjectsInRadar(IdentificatorModel identificatorModel) => cache.gameObjectsInRadar(identificatorModel);

    public List<GameObject> getListPlayers(IdentificatorModel identificator) => cachePlayer.getCurrentPlayers(identificator);

    public bool loadRadar(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => cache.loadRadar(identificator, spacecraft);

    public int radiusRadar(IdentificatorModel identificator) => cache.radiusRadar(identificator);

    public void removeGameobjectFromRadar(IdentificatorModel identificator, GameObject gameObject)
    {
        cache.removeObjectFromRadar(identificator, gameObject);
        cachePlayer.removePlayer(identificator, gameObject);
    }

    public void removeRadar(IdentificatorModel identificator) => cache.removeRadar(identificator);
}