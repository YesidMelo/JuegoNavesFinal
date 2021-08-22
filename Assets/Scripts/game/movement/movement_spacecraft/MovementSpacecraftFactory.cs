using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpacecraftFactory 
{
    public AbstractMovementSpacecraft getMovementSpacecraft(Move move, GameObject spacecraft) {
        switch (move) {
            case Move.FORWARD:
                return new ForwardMovement(spacecraft);
            case Move.LEFT:
                return new LeftMovement(spacecraft);
            case Move.RIGT:
                return new RigthMovement(spacecraft);
            case Move.POINER_ENEMY:
                return new PointingEnemy(spacecraft);
            case Move.POINTER_PLAYER:
                return new PointingPlayer(spacecraft);
            case Move.STOP:
            default:
                return new StopMovement(spacecraft);
        }
    }
}
