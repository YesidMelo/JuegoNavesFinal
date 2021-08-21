using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFactory 
{
    public AbstractMovement getMovement(SideSpacecraft side) {
        switch (side) {
            case SideSpacecraft.PLAYER:
                return new PlayerMovement();
            case SideSpacecraft.ENEMY:
            default:
                return new EnemyMovement();
        }
    }
}
