using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingEnemy : AbstractMovementSpacecraft
{

    

    public PointingEnemy(GameObject spaceCraftToMove) : base(spaceCraftToMove){}

    public override void move()
    {
        loadEnemy();
    }
}
