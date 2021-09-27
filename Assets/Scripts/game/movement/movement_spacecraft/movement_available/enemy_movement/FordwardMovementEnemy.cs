using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FordwardMovementEnemy : AbstractMovementSpacecraft
{
    public FordwardMovementEnemy(GameObject spaceCraftToMove) : base(spaceCraftToMove) {}

    public override void move()
    {
        spaceCraftToMove.transform.Translate(0, speedSpacecraft * Time.deltaTime, 0);
    }
}
