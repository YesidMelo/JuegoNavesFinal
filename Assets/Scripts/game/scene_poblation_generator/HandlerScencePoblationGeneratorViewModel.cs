using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerScencePoblationGeneratorViewModelDelegate {

}

public interface HandlerScencePoblationGeneratorViewModel {
    HandlerScencePoblationGeneratorViewModelDelegate myDelegate { get; set; }

    void addEnemy(SpacecraftEnemy spacecraft, GameObject gameObject);
    bool isAllPoblation();
    int getEnemiesMissingInThePopulation(SpacecraftEnemy enemy);
    Level currentLevel { get; }
    bool isGameInPause();

}

public class HandlerScencePoblationGeneratorViewModelImpl : HandlerScencePoblationGeneratorViewModel
{
    private HandlerScencePoblationGeneratorViewModelDelegate _myDelegate;
    private LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();

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

    public void addEnemy(SpacecraftEnemy spacecraft, GameObject gameObject)=> addEnemyUseCase.invoke(spacecraftEnemy: spacecraft, gameObject: gameObject);


    public int getEnemiesMissingInThePopulation(SpacecraftEnemy enemy) => getEnemiesMissingInThePopulationUseCase.invoke(enemy: enemy);

    public bool isAllPoblation() => isAllPoblationUseCase.invoke();

    public bool isGameInPause() => isGameInPauseUseCase.invoke();

}