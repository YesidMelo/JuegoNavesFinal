using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerRadarEnemyPlayersViewModelDelegate { }
public interface HandlerRadarEnemyPlayersViewModel {
    HandlerRadarEnemyPlayersViewModelDelegate myDelegate { get; set; }
    List<GameObject> getCurrentList(IdentificatorModel identificator);
    GameObject getCurrentPlayer(IdentificatorModel identificator);
    bool isGameInPause();
}

public class HandlerRadarEnemyPlayersViewModelImpl : HandlerRadarEnemyPlayersViewModel
{
    private SpacecraftEnemyGetListPlayersUseCase getListPlayersUseCase = new SpacecraftEnemyGetListPlayersUseCaseImpl();
    private SpacecraftEnemyCurrentPlayerUseCase getCurrentPlayerUseCase = new SpacecraftEnemyCurrentPlayerUseCaseImpl();
    private StatusGameIsGameInPauseUseCase isGameInPauseUseCase = new StatusGameIsGameInPauseUseCaseImpl();

    private HandlerRadarEnemyPlayersViewModelDelegate _myDelegate;

    public HandlerRadarEnemyPlayersViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public List<GameObject> getCurrentList(IdentificatorModel identificator) => getListPlayersUseCase.invoke(identificator);

    public GameObject getCurrentPlayer(IdentificatorModel identificator) => getCurrentPlayerUseCase.invoke(identificator);

    public bool isGameInPause() => isGameInPauseUseCase.invoke();
}