using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerMovementEnemyViewModelDelegate { 

}

public interface HandlerMovementEnemyViewModel {
    List<GameObject> currentGameobjects { get; }
    GameObject currentPlayer(IdentificatorModel identificator);

    HandlerMovementEnemyViewModelDelegate myDelegate { get; set; }
}

public class HandlerMovementEnemyViewModelImpl : HandlerMovementEnemyViewModel
{
    private SpacecraftEnemyGetListGameobjectsInRadarUseCase getListGameobjectsInRadarUseCase = new SpacecraftEnemyGetListGameobjectsInRadarUseCaseImpl();

    private List<GameObject> _listGameObjects = new List<GameObject>();
    private GameObject _currentPlayer;
    private HandlerMovementEnemyViewModelDelegate _myDelegate;

    public HandlerMovementEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public List<GameObject> currentGameobjects => _listGameObjects;

    public GameObject currentPlayer(IdentificatorModel identificator)
    {
        _listGameObjects = getListGameobjectsInRadarUseCase.invoke(identificator);
        if (_listGameObjects.Count != 0)
        {
            _currentPlayer = _listGameObjects[0];
        }
        else {
            _currentPlayer = null;
        }
        return _currentPlayer;
    }
} 