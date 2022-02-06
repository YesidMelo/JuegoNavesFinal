using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationCache {
    void addEnemy(Level level, SpacecraftEnemy spacecraft, GameObject gameObject);
    void removeEnemy(GameObject gameObject, Level level);
    bool isAllPoblation(Level level);
    List<GameObject> getAllEnemies();
    int getEnemiesMissingInThePopulation(Level level, SpacecraftEnemy enemy);
    void removeAllEnemies(List<GameObject> enemies);
    bool clearCache();
}

public class StagePopulationCacheImpl : StagePopulationCache
{
    public delegate bool FilterCondition<T>(T parameter);

    //static variables
    private static StagePopulationCacheImpl instance;

    //static methods
    public static StagePopulationCacheImpl getInstance() {
        if (instance == null) {
            instance = new StagePopulationCacheImpl();
        }
        return instance;
    }

    public static void destroyInstance() => instance = null;

    private List<StagePopulationModel> stagePopulationModels = new List<StagePopulationModel>();

    private List<GameObject> allEnemies = new List<GameObject>();
    
    private StagePopulationCacheImpl() {
        initStagePopulationModels();
    }

    //public methods
    public void addEnemy(Level level, SpacecraftEnemy spacecraft, GameObject gameObject)
    {
        if (gameObject.name.Contains(Constants.nameSpawmerPoblation)) return;

        List<StagePopulationModel> listStagePopulationModelByLevel = HelpersList.filter(
            currentList: stagePopulationModels,
            (StagePopulationModel current) => {return current.level == level;}
        );

        if (HelpersList.isNullOrEmpty(currentList: listStagePopulationModelByLevel)) return;

        StagePopulationModel model = HelpersList.first(currentList: listStagePopulationModelByLevel);
        List<GameObject> currentList = model.dictionaryEnemies[spacecraft];

        if (currentList.Contains(gameObject)) return;
        if (model.dictionaryCounterEnemies[spacecraft] >= level.getMaxEnemies(currentEspacecraft: spacecraft)) return;

        allEnemies.Add(gameObject);
        model.dictionaryEnemies[spacecraft].Add(gameObject);
        model.dictionaryCounterEnemies[spacecraft] = model.dictionaryEnemies[spacecraft].Count;
    }

    public void removeEnemy(GameObject gameObject, Level level)
    {
        List<StagePopulationModel> listStagePopulationByLevel = HelpersList.filter(
            currentList: stagePopulationModels,
            myCondition: (StagePopulationModel model) => {
                return model.level == level;
            }
        );

        if (HelpersList.isNullOrEmpty(currentList: listStagePopulationByLevel)) return;
        StagePopulationModel model = HelpersList.first(currentList: listStagePopulationByLevel);
        if (model == null) return;

        foreach (SpacecraftEnemy spacecraftEnemy in Enum.GetValues(typeof(SpacecraftEnemy))) {
            removeEnemyFromList(
                model: model,
                spacecraftEnemy: spacecraftEnemy
            );
        }

    }

    public bool isAllPoblation(Level level)
    {

        List<StagePopulationModel> listFilteredByLevel = HelpersList.filter(
            currentList: stagePopulationModels,
            (StagePopulationModel model) => {
                return model.level == level;
            }
        );

        if (HelpersList.isNullOrEmpty(currentList: listFilteredByLevel)) return false;

        StagePopulationModel stagePopulationModel = HelpersList.first(currentList: listFilteredByLevel);

        foreach (KeyValuePair<SpacecraftEnemy, int> entry in stagePopulationModel.dictionaryCounterEnemies) {
            if (entry.Value >= level.getMaxEnemies(currentEspacecraft: entry.Key)) continue;
            return false;
        }

        return true;
    }

    public int getEnemiesMissingInThePopulation(Level level, SpacecraftEnemy enemy)
    {
        List<StagePopulationModel> listFiltered = HelpersList.filter(
            currentList: stagePopulationModels,
            (StagePopulationModel model) => {
                return model.level == level;
            }
        );

        if (HelpersList.isNullOrEmpty(currentList: listFiltered)) return 0;

        StagePopulationModel model = HelpersList.first(currentList: listFiltered);
        return model.dictionaryCounterEnemies[enemy];
    }

    public List<GameObject> getAllEnemies() => allEnemies;

    public void removeAllEnemies(List<GameObject> enemies)
    {
        foreach (GameObject currentEnemy in enemies) {
            foreach (Level level in Enum.GetValues(typeof(Level))) {
                removeEnemy(gameObject: currentEnemy, level: level);
            }
        }
    }

    public bool clearCache() {
        allEnemies.Clear();
        stagePopulationModels.Clear();
        return true;
    }

    //private methods
    
    private void initStagePopulationModels() {
        foreach (Level currentLevel in Enum.GetValues(typeof(Level))) {
            StagePopulationModel model = new StagePopulationModel();
            model.level = currentLevel;

            foreach (SpacecraftEnemy currentSpacecraft in Enum.GetValues(typeof(SpacecraftEnemy))) {
                model.dictionaryEnemies.Add(currentSpacecraft, new List<GameObject>());
                model.dictionaryCounterEnemies.Add(currentSpacecraft, 0);
            }

            stagePopulationModels.Add(model);
        }
    }

    private void removeEnemyFromList(
        StagePopulationModel model, 
        SpacecraftEnemy spacecraftEnemy
    ) {
        allEnemies.Clear();
        model.dictionaryEnemies[spacecraftEnemy].Clear();
        model.dictionaryCounterEnemies[spacecraftEnemy] = model.dictionaryEnemies[spacecraftEnemy].Count; 
    }

}