using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationRepository {
    void addEnemy(Level level, SpacecraftEnemy spacecraft, GameObject gameObject);
    void removeEnemy(GameObject gameObject);
    bool isAllPoblation(Level level);
    Dictionary<SpacecraftEnemy, int> getEnemiesMissingInThePopulation(Level level);
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

    public Dictionary<SpacecraftEnemy, int> getEnemiesMissingInThePopulation(Level level) => cache.getEnemiesMissingInThePopulation(level: level);

    public bool isAllPoblation(Level level) => cache.isAllPoblation(level: level);

    public void removeEnemy(GameObject gameObject) => cache.removeEnemy(gameObject: gameObject);
    
}