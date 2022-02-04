using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGameConfigLevel : MonoBehaviour, InteractionGameConfigLevelViewModelDelegate
{
    public GameObject prefabPlayer;
    public GameObject prefabSpawnerPoblation;
    public HandlerCameraPlayer handlerCameraPlayer;
    public InteractionGameUI interactionGameUI;
    public GameObject prefabPortalGenerator;

    private GameObject _currentSpacecraftPlayer;
    private GameObject _currentSpawnerPoblation;
    private GameObject _currentPortalGenerator;
    private InteractionGameConfigLevelViewModel viewModel = new InteractionGameConfigLevelViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
        instanceSpacecraftPlayer();
        instanceSpawmerPoblation();
        instancePortalGenerator();
        configCameraPlayer();
    }

    //private methods
    private void instanceSpacecraftPlayer() {
        _currentSpacecraftPlayer = viewModel.currentPlayer;

        if (_currentSpacecraftPlayer != null) return;

        _currentSpacecraftPlayer = Instantiate(prefabPlayer, interactionGameUI.getInitialPosition, Quaternion.identity);
        _currentSpacecraftPlayer.transform.name = Constants.namePlayer;
        viewModel.setCurrentPlayer(currentPlayer: _currentSpacecraftPlayer);

    }

    private void instanceSpawmerPoblation() {
        _currentSpawnerPoblation = viewModel.currentSpawmPopulation;
        if (_currentSpawnerPoblation != null) return;
        _currentSpawnerPoblation = Instantiate(prefabSpawnerPoblation, Constants.positionSpawmerPosition, Quaternion.identity);
        _currentSpawnerPoblation.transform.name = Constants.nameSpawmerPoblation;
        viewModel.setCurrentSpawmPopulation(currentSpawmPopulation: _currentSpawnerPoblation);
    }

    private void instancePortalGenerator() {
        _currentPortalGenerator = viewModel.currentPortalGenerator;

        if (_currentPortalGenerator != null) return;
        _currentPortalGenerator = Instantiate(prefabPortalGenerator, Constants.positionPortalGeneratorPosition, Quaternion.identity);
        _currentPortalGenerator.transform.name = Constants.namePortalGenerator;
        viewModel.setCurrentPortalGenerator(portalGenerator: _currentPortalGenerator);
        
    }

    private void configCameraPlayer() {
        if (handlerCameraPlayer == null) return;
        handlerCameraPlayer.currentPlayer = _currentSpacecraftPlayer;
    }

}
