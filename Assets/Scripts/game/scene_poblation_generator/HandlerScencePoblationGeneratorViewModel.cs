using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerScencePoblationGeneratorViewModelDelegate {
    void notifyLoadLevel();
}

public interface HandlerScencePoblationGeneratorViewModel {
    HandlerScencePoblationGeneratorViewModelDelegate myDelegate { get; set; }
    Level currentLevel { get; }
    void updateLevel(Level level);
}

public class HandlerScencePoblationGeneratorViewModelImpl : HandlerScencePoblationGeneratorViewModel
{
    private HandlerScencePoblationGeneratorViewModelDelegate _myDelegate;
    private LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();
    private LevelUpdateLevelUseCase updateLevelUseCase = new LevelUpdateLevelUseCaseImpl();

    public List<GameObject> currentPoblation => new List<GameObject>();

    public HandlerScencePoblationGeneratorViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public Level currentLevel => getCurrentLevelUseCase.invoke();

    public void updateLevel(Level level) => updateLevelUseCase.invoke(level: level);
}