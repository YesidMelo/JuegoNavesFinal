using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingPlayer : AbstractMovementSpacecraft
{
    public PointingPlayer(GameObject spaceCraftToMove) : base(spaceCraftToMove){}

    public override void move()
    {
        loadEnemy();
    }
}
