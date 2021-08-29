using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbstractMovement
{
    public PlayerMovement(GameObject spacecraft) : base(spacecraft){}

    public override void movementAttack()
    {
        pointingPlayer.move();
        forwardMovement.move();
    }

    public override void movementDefence() => forwardMovement.move();

    public override void movementFordward() => forwardMovement.move();

    public override void movementPatrol() {
        action = Action.FORDWARD;
    }

    public override void movementStop() => stopMovement.move();
}
