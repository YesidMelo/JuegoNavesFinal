using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionGameConfigLevelViewModelDelegate { }

public interface InteractionGameConfigLevelViewModel {
    InteractionGameConfigLevelViewModelDelegate myDelegate { set; }
    GameObject currentPlayer { get; }
    void setCurrentPlayer(GameObject currentPlayer);
}

public class InteractionGameConfigLevelViewModelImpl : InteractionGameConfigLevelViewModel
{
    private GetCurrentPlayerUseCase getCurrentPlayerUseCase = new GetCurrentPlayerUseCaseImpl();
    private SetCurrentPlayerUseCase setCurrentPlayerUseCase = new SetCurrentPlayerUseCaseImpl();

    private InteractionGameConfigLevelViewModelDelegate _myDelegate;

    public InteractionGameConfigLevelViewModelDelegate myDelegate { set { _myDelegate = value; } }

    public GameObject currentPlayer => getCurrentPlayerUseCase.invoke();

    public void setCurrentPlayer(GameObject currentPlayer) => setCurrentPlayerUseCase.invoke(currentPlayer: currentPlayer);
}