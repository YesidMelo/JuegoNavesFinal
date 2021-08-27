using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementListener : AbstractMovementDelegate
{
    private HandlerSpacecraftMovement spacecraftMovement;
    public MovementListener(
        HandlerSpacecraftMovement spacecraftMovement
    ) {
        this.spacecraftMovement = spacecraftMovement;
    }

    public void updateAction(Action currentAction)
    {
        spacecraftMovement.currentAction = currentAction;
    }

}
