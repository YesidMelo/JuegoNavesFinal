using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbstractMovement
{

    private CurrentMovementJoysticUseCase currentMovementJoysticUseCase = new CurrentMovementJoysticUseCaseImpl();


    public PlayerMovement(GameObject spacecraft) : base(spacecraft) {}

    public override void movementAttack()
    {
        joysticMovement.move();
    }

    public override void movementDefence() {
        joysticMovement.move();
    }

    public override void movementFordward() => action = Action.DEFENSE;

    public override void movementPatrol() => action = Action.DEFENSE;

    public override void movementStop() => action = Action.DEFENSE;

}