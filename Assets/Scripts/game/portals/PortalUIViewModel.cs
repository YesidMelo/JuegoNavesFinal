using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalUIViewModelDelegate { 
}

public interface PortalUIViewModel {
    PortalUIViewModelDelegate myDelegate { set; get; }
    Level getCurrentLevel { get; }
    void changeLevel(Level level);
}

public class PortalUIViewModelImpl : PortalUIViewModel
{
    private LevelUpdateLevelUseCase updateLevelUseCase = new LevelUpdateLevelUseCaseImpl();
    private LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();

    private PortalUIViewModelDelegate _myDelegate;

    public PortalUIViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public Level getCurrentLevel => getCurrentLevelUseCase.invoke();

    public void changeLevel(Level level)
    {
        if (level == getCurrentLevelUseCase.invoke()) return;
        updateLevelUseCase.invoke(level: level);
    }
}