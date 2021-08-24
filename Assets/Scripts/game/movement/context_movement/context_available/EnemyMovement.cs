using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : AbstractMovement
{
    public EnemyMovement(GameObject spacecraft) : base(spacecraft) { }
    

    public override void movementAttack()
    {
        
    }

    public override void movementChangeEnemy()
    {
        switch (currentMove) {
            case Move.FORWARD:
                forwardMovement.move();
                return;
            case Move.LEFT:
                leftMovement.move();
                return;
            case Move.RIGT:
                rigthMovement.move();
                return;
            case Move.POINER_ENEMY:
                pointingEnemy.move();
                return;
            case Move.POINTER_PLAYER:
                pointingEnemy.move();
                return;
            case Move.STOP:
            default:
                return;
        }
    }

    public override void movementDefence()
    {
        
    }
}
