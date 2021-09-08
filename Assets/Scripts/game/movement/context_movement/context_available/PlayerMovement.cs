using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbstractMovement
{

    private CurrentMoveUseCase currentMovementUseCase = new CurrentMoveUseCaseImpl();

    public PlayerMovement(GameObject spacecraft) : base(spacecraft) {}

    public override void movementAttack()
    {
       //pointingStructureToEnemy.move();
    }

    public override void movementDefence() { }

    public override void movementFordward() {
        selectMovement();
    }

    public override void movementPatrol() => action = Action.ATTACK;

    public override void movementStop() => stopMovement.move();

    /// private method
    private void selectMovement() {
        switch (currentMovementUseCase.invoke()) {
            case Move.TOP:
                topMovement.move();
                return;
            case Move.LEFT:
                leftMovement.move();
                return;
            case Move.RIGT:
                rigthMovement.move();
                return;
            case Move.STOP:
            default:
                stopMovement.move();
                return;
        }

    }

}