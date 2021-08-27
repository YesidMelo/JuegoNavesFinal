using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : AbstractMovement
{
    public EnemyMovement(GameObject spacecraft) : base(spacecraft) { }


    public override void movementAttack()
    {
        pointingEnemy.move();
        forwardMovement.move();
    }

    public override void movementDefence() => forwardMovement.move();

    public override void movementFordward() => forwardMovement.move();

    public override void movementStop() => stopMovement.move();

}