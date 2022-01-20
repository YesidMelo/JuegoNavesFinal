using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface PortalUIViewModelDelegate {
    Task deleteAllEnemies();
}

public interface PortalUIViewModel {
    PortalUIViewModelDelegate myDelegate { set; get; }
    Level getCurrentLevel { get; }
    void changeLevel(Level level);
    public List<GameObject> getAllEnemies();
}

public class PortalUIViewModelImpl : PortalUIViewModel
{
    private GetAllEnemiesUseCase getAllEnemiesUseCase = new GetAllEnemiesUseCaseImpl();
    private LevelUpdateLevelUseCase updateLevelUseCase = new LevelUpdateLevelUseCaseImpl();
    private LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();
    private StatusGameUpdateStatusUseCase updateStatusUseCase = new StatusGameUpdateStatusUseCaseImpl();
    private StagePopulationClearCacheUseCase stagePopulationClearUseCase = new StagePopulationClearCacheUseCaseImpl();


    private PortalUIViewModelDelegate _myDelegate;

    public PortalUIViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public Level getCurrentLevel => getCurrentLevelUseCase.invoke();

    public void changeLevel(Level level)
    {
        Task.Run(async () => {

            try
            {
                if (_myDelegate == null) return;
                if (level == getCurrentLevelUseCase.invoke()) return;
                updateStatusUseCase.invoke(statusGame: StatusGame.CHANGE_LEVEL);
                await _myDelegate.deleteAllEnemies();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
            finally {
                updateLevelUseCase.invoke(level: level);
                updateStatusUseCase.invoke(statusGame: StatusGame.IN_GAME);
            }
        });
    }

    public List<GameObject> getAllEnemies() => getAllEnemiesUseCase.invoke();
}