using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpacecraftFactory 
{
    public AbstractMovementSpacecraft getMovementSpacecraft(Move move, GameObject spacecraft) {
        switch (move) {
            case Move.BOTTOM:
                return new BottomMovement(spacecraft);
            case Move.FORWARD:
                return new ForwardMovement(spacecraft);
            case Move.JOYSTIC:
                return new JoysticMovement(spacecraft);
            case Move.LEFT:
                return new LeftMovement(spacecraft);
            case Move.RIGT:
                return new RigthMovement(spacecraft);
            case Move.POINER_ENEMY:
                return new PointingEnemy(spacecraft);
            case Move.POINTER_PLAYER:
                return new PointingPlayer(spacecraft);
            case Move.POINTER_PATROL:
                return new PointingPatrol(spacecraft);
            case Move.POINTER_STRUCTURE_TO_ENEMY:
                return new PointStructureToEnemyMovement(spacecraft);
            case Move.RESTORE_ROTATION:
                return new RestoreRotationMovement(spacecraft);
            case Move.TOP:
                return new TopMovement(spacecraft);
            case Move.STOP:
            default:
                return new StopMovement(spacecraft);
        }
    }
}
