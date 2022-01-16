using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BackgroundUIViewModelDelegate {
    void updateBackground(Level level);
}

public interface BackgroundUIViewModel {
    BackgroundUIViewModelDelegate myDelegate { get; set; }

    Level getCurrentLevel();

    void checkCurrentLevel();

}

public class BackgroundUIViewModelImpl : BackgroundUIViewModel
{
    private BackgroundGetCurrentLevelUseCase backgroundGetCurrentLevelUseCase = new BackgroundGetCurrentLevelUseCaseImpl();
    
    private BackgroundUIViewModelDelegate _myDelegate;
    private Level currentLevel;

    public BackgroundUIViewModelDelegate myDelegate { get => _myDelegate; set => _myDelegate = value; }

    public void checkCurrentLevel()
    {
        Level levelFromUseCase = backgroundGetCurrentLevelUseCase.invoke();

        if (currentLevel == levelFromUseCase) return;
        currentLevel = levelFromUseCase;

        if (_myDelegate == null) return;
        _myDelegate.updateBackground(currentLevel);
    }

    public Level getCurrentLevel() => currentLevel;
}