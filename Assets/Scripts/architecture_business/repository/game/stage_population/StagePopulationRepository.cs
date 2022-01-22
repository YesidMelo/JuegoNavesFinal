using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationRepository {
    void addEnemy(Level level, SpacecraftEnemy spacecraft, GameObject gameObject);
    void removeEnemy(GameObject gameObject, Level level);
    bool isAllPoblation(Level level);
    int getEnemiesMissingInThePopulation(
        Level level,
        SpacecraftEnemy enemy
    );
    List<GameObject> getAllEnemies();
    void removeAllEnemies(List<GameObject> enemies);
    bool clearCache();
}
public class StagePopulationRepositoryImpl : StagePopulationRepository
{

    private StagePopulationCache cache = StagePopulationCacheImpl.getInstance();

    public void addEnemy(
        Level level, 
        SpacecraftEnemy spacecraft, 
        GameObject gameObject
    ) => cache.addEnemy(
        level: level,
        spacecraft: spacecraft,
        gameObject: gameObject
    );

    public List<GameObject> getAllEnemies() => cache.getAllEnemies();

    public int getEnemiesMissingInThePopulation(
        Level level,
        SpacecraftEnemy enemy
    ) => cache.getEnemiesMissingInThePopulation(level: level, enemy: enemy);

    public bool isAllPoblation(Level level) => cache.isAllPoblation(level: level);

    public void removeAllEnemies(List<GameObject> enemies) => cache.removeAllEnemies(enemies: enemies);

    public void removeEnemy(GameObject gameObject, Level level) => cache.removeEnemy(gameObject: gameObject, level: level);
    public bool clearCache() => cache.clearCache();

}