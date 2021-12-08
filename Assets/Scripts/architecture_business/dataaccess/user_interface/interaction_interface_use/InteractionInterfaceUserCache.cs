using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface InteractionInterfaceUserCache {

    Action currentActionSpacecraft { get; }
    Vector2 currentDirection { get; }
    GameObject currentPlayer { get; }
    GameObject currentSpawmPopulation { get; }

    Task deleteCurrentPlayer();
    Task deleteCurrentSpawmPopulation();

    void updateActionSpacecraft(Action action);
    void updatePositionJoystic(Vector2 direction);

    void setCurrentPlayer(GameObject currentPlayer);
    void setCurrentSpawmPopulation(GameObject currentSpawmPopulation);
}

public class InteractionInterfaceUserCacheImpl : InteractionInterfaceUserCache
{

    // static variables
    private static InteractionInterfaceUserCacheImpl instance;

    //static methods
    public static InteractionInterfaceUserCacheImpl getInstance() {
        if (instance == null) {
            instance = new InteractionInterfaceUserCacheImpl();
        }
        return instance;
    }

    // class

    private Action _currentActionSpacecraft = Action.STOP;
    private Vector2 _currentDirection = new Vector2(0,0);
    private GameObject _currentPlayer;
    private GameObject _currentSpawmPopulation;
  
    public Vector2 currentDirection => _currentDirection;

    public Action currentActionSpacecraft => _currentActionSpacecraft;

    public GameObject currentPlayer => _currentPlayer;

    public GameObject currentSpawmPopulation => _currentSpawmPopulation;

    public void updatePositionJoystic(Vector2 direction) => _currentDirection = direction;


    public void updateActionSpacecraft(Action action) => _currentActionSpacecraft = action;

    public void setCurrentPlayer(GameObject currentPlayer) => _currentPlayer = currentPlayer;

    public void setCurrentSpawmPopulation(GameObject currentSpawmPopulation) { 
        _currentSpawmPopulation = currentSpawmPopulation; 
    }

    public async Task deleteCurrentPlayer() => _currentPlayer = null;

    public async Task deleteCurrentSpawmPopulation() => _currentSpawmPopulation = null;
}
