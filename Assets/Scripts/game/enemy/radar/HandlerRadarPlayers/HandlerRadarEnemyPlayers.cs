using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRadarEnemyPlayers : MonoBehaviour, HandlerRadarEnemyPlayersViewModelDelegate
{
    public HandlerRadarEnemy handlerRadar;
    public List<GameObject> currentList;
    public GameObject currentPlayer;

    private HandlerRadarEnemyPlayersViewModel viewModel = new HandlerRadarEnemyPlayersViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (viewModel.isGameInPause()) return;
        checkEnemiesFromRadar();
    }

    private void checkEnemiesFromRadar() {
        if (viewModel == null) return;
        if (handlerRadar == null) return;
        if (handlerRadar.identificator == null) return;
        currentList = viewModel.getCurrentList(handlerRadar.identificator);
        currentPlayer = viewModel.getCurrentPlayer(handlerRadar.identificator);
    }
}
