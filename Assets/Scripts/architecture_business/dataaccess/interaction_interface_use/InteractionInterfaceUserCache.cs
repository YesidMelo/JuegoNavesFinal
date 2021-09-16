using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionInterfaceUserCache {

    Action currentActionSpacecraft { get; }
    Vector2 currentDirection { get; }

    void updateActionSpacecraft(Action action);
    void updatePositionJoystic(Vector2 direction);
}

public class InteractionInterfaceUserCacheImpl : InteractionInterfaceUserCache
{

    // static
    private static InteractionInterfaceUserCacheImpl instance;

    public static InteractionInterfaceUserCacheImpl getInstance() {
        if (instance == null) {
            instance = new InteractionInterfaceUserCacheImpl();
        }
        return instance;
    }

    // class

    private InteractionInterfaceUserCacheImpl() { }

    private Action _currentActionSpacecraft = Action.STOP;
    private Vector2 _currentDirection = new Vector2(0,0);
  
    public Vector2 currentDirection => _currentDirection;


    public Action currentActionSpacecraft => _currentActionSpacecraft;

    public void updatePositionJoystic(Vector2 direction) => _currentDirection = direction;


    public void updateActionSpacecraft(Action action) => _currentActionSpacecraft = action;
}
