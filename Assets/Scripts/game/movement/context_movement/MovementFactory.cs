using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFactory 
{
    public AbstractMovement getMovement(SideSpacecraft side, GameObject spacecraft) {
        switch (side) {
            case SideSpacecraft.PLAYER:
                return new PlayerMovement(spacecraft);
            case SideSpacecraft.ENEMY:
            default:
                return new EnemyMovement(spacecraft);
        }
    }
}
