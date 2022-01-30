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
    bool playerInPortal { get; }
    void changeLevel(Level level);
    public List<GameObject> getAllEnemies();
    public void setCurrentPortal(PortalModel portalModel);
}

public class PortalUIViewModelImpl : PortalUIViewModel
{
    private readonly GetAllEnemiesUseCase getAllEnemiesUseCase = new GetAllEnemiesUseCaseImpl();
    private readonly LevelUpdateLevelUseCase updateLevelUseCase = new LevelUpdateLevelUseCaseImpl();
    private readonly LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();
    private readonly StatusGameUpdateStatusUseCase updateStatusUseCase = new StatusGameUpdateStatusUseCaseImpl();
    private readonly PortalAddPlayerInPortalUseCase addPlayerInPortalUseCase = new PortalAddPlayerInPortalUseCaseImpl();
    private readonly PortalIsPlayerInPortalUseCase isPlayerInPortalUseCase = new PortalIsPlayerInPortalUseCaseImpl();


    private PortalUIViewModelDelegate _myDelegate;

    public PortalUIViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public Level getCurrentLevel => getCurrentLevelUseCase.invoke();

    public bool playerInPortal => isPlayerInPortalUseCase.invoke();

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

    public void setCurrentPortal(PortalModel portalModel) => addPlayerInPortalUseCase.invoke(currentPortal: portalModel);

}