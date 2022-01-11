using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationCache {
    void addEnemy(Level level, SpacecraftEnemy spacecraft, GameObject gameObject);
    void removeEnemy(GameObject gameObject);
    bool isAllPoblation(Level level);
    List<GameObject> getAllEnemies();
    Dictionary<SpacecraftEnemy, int> getEnemiesMissingInThePopulation(Level level);
    void removeAllEnemies(List<GameObject> enemies);
    bool clearCache();
}

public class StagePopulationCacheImpl : StagePopulationCache
{
    //static variables
    private static StagePopulationCacheImpl instance;

    //static methods
    public static StagePopulationCacheImpl getInstance() {
        if (instance == null) {
            instance = new StagePopulationCacheImpl();
        }
        return instance;
    }

    private List<GameObject> allEnemies = new List<GameObject>();
    private Dictionary<Level, Dictionary<SpacecraftEnemy, List<GameObject>>> spacecraftByLevel = new Dictionary<Level, Dictionary<SpacecraftEnemy, List<GameObject>>>();
    private Dictionary<Level, Dictionary<SpacecraftEnemy, int>> poblationByLevel = new Dictionary<Level, Dictionary<SpacecraftEnemy, int>>();

    private StagePopulationCacheImpl() {
        initDictionary();
    }

    //public methods
    public void addEnemy(Level level, SpacecraftEnemy spacecraft, GameObject gameObject)
    {
        List<GameObject> currentList = spacecraftByLevel[level][spacecraft];
        if (currentList.Contains(gameObject)) return;
        if (currentList.Count >= level.getMaxEnemies(spacecraft)) return;
        currentList.Add(gameObject);
        allEnemies.Add(gameObject);
        poblationByLevel[level][spacecraft] = currentList.Count;
    }

    public void removeEnemy(GameObject gameObject)
    {
        foreach (Level currentLevel in Enum.GetValues(typeof(Level))) {
            foreach (SpacecraftEnemy curretnSpacecraft in Enum.GetValues(typeof(SpacecraftEnemy))) {
                List<GameObject> currentList = spacecraftByLevel[currentLevel][curretnSpacecraft];
                if (currentList.Count == 0) break;
                if (!currentList.Contains(gameObject)) continue;
                currentList.Remove(gameObject);
                allEnemies.Remove(gameObject);
                return;
            }
        }
    }

    public bool isAllPoblation(Level level)
    {
        if (poblationByLevel.Count == 0) {
            initDictionary();
        }
        Dictionary<SpacecraftEnemy, int> dictionary = poblationByLevel[level];
        if (dictionary == null) return false;
        if (dictionary.Count == 0) return false;
        foreach (SpacecraftEnemy spacecraft in Enum.GetValues(typeof(SpacecraftEnemy))) {
            int currentPoblation = dictionary[spacecraft];
            if (currentPoblation >= level.getMaxEnemies(spacecraft)) continue;
            return false;
        }
        return true;
    }

    public Dictionary<SpacecraftEnemy, int> getEnemiesMissingInThePopulation(Level level)
    {
        Dictionary<SpacecraftEnemy, int> dictionaryCreation = new Dictionary<SpacecraftEnemy, int>();
        Dictionary<SpacecraftEnemy, int> dictionary = poblationByLevel[level];
        if (dictionary.Count == 0) return dictionaryCreation;

        foreach (SpacecraftEnemy spacecraft in Enum.GetValues(typeof(SpacecraftEnemy)))
        {
            int currentPoblation = dictionary[spacecraft];
            int maxEnemiesType = level.getMaxEnemies(spacecraft);
            if (currentPoblation >= maxEnemiesType) continue;
            dictionaryCreation[spacecraft] = maxEnemiesType - currentPoblation;
        }

        return dictionaryCreation;
    }

    public List<GameObject> getAllEnemies() => allEnemies;

    public void removeAllEnemies(List<GameObject> enemies)
    {
        foreach (GameObject currentEnemy in enemies) {
            removeEnemy(currentEnemy);
        }
    }

    public bool clearCache() {
        allEnemies.Clear();
        spacecraftByLevel.Clear();
        poblationByLevel.Clear();
        return true;
    }

    //private methods
    private void initDictionary() {
        foreach (Level currentLevel in Enum.GetValues(typeof(Level)))
        {
            Dictionary<SpacecraftEnemy, List<GameObject>> currentSpacecraft = new Dictionary<SpacecraftEnemy, List<GameObject>>();
            Dictionary<SpacecraftEnemy, int> currentPopulation = new Dictionary<SpacecraftEnemy, int>();
            foreach (SpacecraftEnemy spacecraft in Enum.GetValues(typeof(SpacecraftEnemy)))
            {
                currentSpacecraft.Add(spacecraft, new List<GameObject>());
                currentPopulation.Add(spacecraft, 0);
            }
            spacecraftByLevel.Add(currentLevel, currentSpacecraft);
            poblationByLevel.Add(currentLevel, currentPopulation);
        }
    }

    
}