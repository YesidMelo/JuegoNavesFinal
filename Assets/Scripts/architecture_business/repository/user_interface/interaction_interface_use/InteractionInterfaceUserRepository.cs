using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionInterfaceUserRepository {

    Action currentActionSpacecraft { get; }

    Vector2 currentMovementJoystic { get; }
    GameObject currentPlayer { get; }
    GameObject currentSpawmPopulation { get; }
    void updateActionSpacecraft(Action action);

    void updateMovementJoystic(Vector2 direction);
    void setCurrentPlayer(GameObject currentPlayer);
    void setCurrentSpawmPopulation(GameObject spawmPopulation);
}

public class InteractionInterfaceUserRepositoryImpl : InteractionInterfaceUserRepository
{

    private InteractionInterfaceUserCache interactionInterfaceUserCache = InteractionInterfaceUserCacheImpl.getInstance();

    public Action currentActionSpacecraft => interactionInterfaceUserCache.currentActionSpacecraft;
    public Vector2 currentMovementJoystic => interactionInterfaceUserCache.currentDirection;

    public GameObject currentPlayer => interactionInterfaceUserCache.currentPlayer;

    public GameObject currentSpawmPopulation => interactionInterfaceUserCache.currentSpawmPopulation;

    public void setCurrentPlayer(GameObject currentPlayer) => interactionInterfaceUserCache.setCurrentPlayer(currentPlayer: currentPlayer);

    public void setCurrentSpawmPopulation(GameObject spawmPopulation) {
        interactionInterfaceUserCache.setCurrentSpawmPopulation(currentSpawmPopulation: spawmPopulation);
    }

    public void updateActionSpacecraft(Action action) => interactionInterfaceUserCache.updateActionSpacecraft(action);
    
    public void updateMovementJoystic(Vector2 direction) => interactionInterfaceUserCache.updatePositionJoystic(direction);
}
