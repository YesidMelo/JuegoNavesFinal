using System.Collections.Generic;
using UnityEngine;

public interface HandlerRotationPlayerViewModelDelegate { 

}

public interface HandlerRotationPlayerViewModel {
    HandlerRotationPlayerViewModelDelegate myDelegate { get; set; }
    
    Action currentAction { get; }
    List<GameObject> getListElementsInRadar { get; }
    GameObject currentEnemy { get; }
}

public class HandlerRotationPlayerViewModelImpl : HandlerRotationPlayerViewModel
{
    private CurrentActionSpacecraftUseCase currentActionSpacecraftUseCase = new CurrentActionSpacecraftUseCaseImpl();
    private SpacecraftPlayerGetListEnemiesUseCase getListEnemiesUseCase = new SpacecraftPlayerGetListEnemiesUseCaseImpl();
    private SpacecraftPlayerGetCurrentEnemyUseCase getCurrentEnemyUseCase = new SpacecraftPlayerGetCurrentEnemyUseCaseImpl();

    private HandlerRotationPlayerViewModelDelegate _myDelegate;

    public HandlerRotationPlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public Action currentAction => currentActionSpacecraftUseCase.invoke();

    public List<GameObject> getListElementsInRadar => getListEnemiesUseCase.invoke();

    public GameObject currentEnemy => getCurrentEnemyUseCase.invoke();
}