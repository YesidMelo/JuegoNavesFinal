using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbstractMovement
{
    public PlayerMovement(GameObject spacecraft) : base(spacecraft) {}

    public override void movementAttack()
    {
        pointingStructureToEnemy.move();
    }

    public override void movementDefence() { }

    public override void movementFordward() { }

    public override void movementPatrol() => action = Action.ATTACK;

    public override void movementStop() => stopMovement.move();

  


}
