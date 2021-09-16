using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionInterfaceUserRepository {

    Action currentActionSpacecraft { get; }

    Vector2 currentMovementJoystic { get; }
    void updateActionSpacecraft(Action action);

    void updateMovementJoystic(Vector2 direction);
}

public class InteractionInterfaceUserRepositoryImpl : InteractionInterfaceUserRepository
{

    private InteractionInterfaceUserCache joysticCache = InteractionInterfaceUserCacheImpl.getInstance();

    public Action currentActionSpacecraft => joysticCache.currentActionSpacecraft;
    public Vector2 currentMovementJoystic => joysticCache.currentDirection;


    public void updateActionSpacecraft(Action action) => joysticCache.updateActionSpacecraft(action);
    
    public void updateMovementJoystic(Vector2 direction) => joysticCache.updatePositionJoystic(direction);
}
