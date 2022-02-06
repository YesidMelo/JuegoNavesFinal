using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface InteractionInterfaceUserCache {

    Action currentActionSpacecraft { get; }
    Vector2 currentDirection { get; }
    GameObject currentPlayer { get; }
    GameObject currentSpawmPopulation { get; }
    GameObject currentPortalGenerator{ get; }

    Task deleteCurrentPlayer();
    Task deleteCurrentSpawmPopulation();
    Task deleteCurrentPortalGenerator();

    void updateActionSpacecraft(Action action);
    void updatePositionJoystic(Vector2 direction);

    void setCurrentPlayer(GameObject currentPlayer);
    void setCurrentSpawmPopulation(GameObject currentSpawmPopulation);
    void setCurrentPortalGenerator(GameObject currentPortalGenerator);
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

    public static void destroyInstance() => instance = null;

    // class

    private Action _currentActionSpacecraft = Action.STOP;
    private Vector2 _currentDirection = new Vector2(0,0);
    private GameObject _currentPlayer;
    private GameObject _currentSpawmPopulation;
    private GameObject _currentPortalGenerator;
  
    public Vector2 currentDirection => _currentDirection;

    public Action currentActionSpacecraft => _currentActionSpacecraft;

    public GameObject currentPlayer => _currentPlayer;

    public GameObject currentSpawmPopulation => _currentSpawmPopulation;

    public GameObject currentPortalGenerator => _currentPortalGenerator;

    public void updatePositionJoystic(Vector2 direction) => _currentDirection = direction;


    public void updateActionSpacecraft(Action action) => _currentActionSpacecraft = action;

    public void setCurrentPlayer(GameObject currentPlayer) => _currentPlayer = currentPlayer;

    public void setCurrentSpawmPopulation(GameObject currentSpawmPopulation) { 
        _currentSpawmPopulation = currentSpawmPopulation; 
    }
    
    public void setCurrentPortalGenerator(GameObject currentPortalGenerator) { 
        _currentPortalGenerator = currentPortalGenerator; 
    }

    public async Task deleteCurrentPlayer() => _currentPlayer = null;

    public async Task deleteCurrentSpawmPopulation() => _currentSpawmPopulation = null;
    public async Task deleteCurrentPortalGenerator() => _currentPortalGenerator = null;
}
