using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerScencePoblationGeneratorViewModelDelegate {
    void notifyLoadLevel();
}

public interface HandlerScencePoblationGeneratorViewModel {
    HandlerScencePoblationGeneratorViewModelDelegate myDelegate { get; set; }

    void addEnemy(Level level, SpacecraftEnemy spacecraft, GameObject gameObject);
    bool isAllPoblation(Level level);
    Dictionary<SpacecraftEnemy, int> getEnemiesMissingInThePopulation(Level level);
    Level currentLevel { get; }
    void updateLevel(Level level);
    bool isGameInPause();

    void checkCurrentLevel();
}

public class HandlerScencePoblationGeneratorViewModelImpl : HandlerScencePoblationGeneratorViewModel
{
    private HandlerScencePoblationGeneratorViewModelDelegate _myDelegate;
    private LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();
    private LevelUpdateLevelUseCase updateLevelUseCase = new LevelUpdateLevelUseCaseImpl();

    private StagePopulationAddEnemyUseCase addEnemyUseCase = new StagePopulationAddEnemyUseCaseImpl();
    private StagePopulationIsAllPoblationUseCase isAllPoblationUseCase = new StagePopulationIsAllPoblationUseCaseImpl();
    private StagePopulationGetEnemiesMissingInThePopulationUseCase getEnemiesMissingInThePopulationUseCase = new StagePopulationGetEnemiesMissingInThePopulationUseCaseImpl();
    private StatusGameIsGameInPauseUseCase isGameInPauseUseCase = new StatusGameIsGameInPauseUseCaseImpl();

    public List<GameObject> currentPoblation => new List<GameObject>();

    public HandlerScencePoblationGeneratorViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public Level currentLevel => getCurrentLevelUseCase.invoke();

    public void addEnemy(Level level, SpacecraftEnemy spacecraft, GameObject gameObject)=> addEnemyUseCase.invoke(level: level, spacecraftEnemy: spacecraft, gameObject: gameObject);

    public void checkCurrentLevel() {
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadLevel();
    }

    public Dictionary<SpacecraftEnemy, int> getEnemiesMissingInThePopulation(Level level) => getEnemiesMissingInThePopulationUseCase.invoke(level: level);

    public bool isAllPoblation(Level level) => isAllPoblationUseCase.invoke(level: level);

    public bool isGameInPause() => isGameInPauseUseCase.invoke();

    public void updateLevel(Level level) { 
        updateLevelUseCase.invoke(level: level);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadLevel();
    }

}