using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGameConfigLevel : MonoBehaviour
{
    public GameObject prefabPlayer;
    public GameObject prefabSpawnerPoblation;
    public HandlerCameraPlayer handlerCameraPlayer;
    public InteractionGameUI interactionGameUI;

    private GameObject _currentSpacecraftPlayer;
    private GameObject _currentSpawnerPoblation;

    private void Awake()
    {
        instanceSpacecraftPlayer();
        instanceSpawmerPoblation();
        configCameraPlayer();
        configPoblation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private methods
    private void instanceSpacecraftPlayer() {
        if (_currentSpacecraftPlayer != null) return;
        _currentSpacecraftPlayer = Instantiate(prefabPlayer, interactionGameUI.getInitialPosition, Quaternion.identity);
        _currentSpacecraftPlayer.transform.name = Constants.namePlayer;

    }

    private void instanceSpawmerPoblation() {
        if (_currentSpawnerPoblation != null) return;
        _currentSpawnerPoblation = Instantiate(prefabSpawnerPoblation, Constants.positionSpawmerPosition, Quaternion.identity);
        _currentSpawnerPoblation.transform.name = Constants.nameSpawmerPoblation;
    }

    private void configCameraPlayer() {
        if (handlerCameraPlayer == null) return;
        handlerCameraPlayer.currentPlayer = _currentSpacecraftPlayer;
    }

    private void configPoblation() {
        if (_currentSpawnerPoblation == null) return;

        HandlerScencePoblationGenerator handler = _currentSpawnerPoblation.GetComponent<HandlerScencePoblationGenerator>();
        if (handler == null) return;
        handler.updateCurrentLevel(Level.LEVEL1_SECTION1);

    }
}
