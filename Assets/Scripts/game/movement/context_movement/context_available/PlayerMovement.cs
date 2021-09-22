using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbstractMovement
{
    private CurrentActionSpacecraftUseCase currentActionSpacecraftUseCase = new CurrentActionSpacecraftUseCaseImpl();

    public PlayerMovement(GameObject spacecraft) : base(spacecraft) {}

    public override void movementAttack()
    {
        action = currentActionSpacecraftUseCase.invoke();
        if (currentActionSpacecraftUseCase.invoke() != Action.ATTACK) return;
        pointingEnemy.move();
        joysticMovement.move();
    }

    public override void movementDefence() {
        action = currentActionSpacecraftUseCase.invoke();
        Debug.Log("Movimiento Defensa");
        if (currentActionSpacecraftUseCase.invoke() != Action.DEFENSE) return;
        restoreRotationMovement.move();
        joysticMovement.move();
    }

    public override void movementFordward() => action = Action.DEFENSE;

    public override void movementPatrol() => action = Action.DEFENSE;

    public override void movementStop() => action = Action.DEFENSE;

}