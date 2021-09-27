using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovementPlayer : AbstractMovementSpacecraft
{
    public StopMovementPlayer(GameObject spaceCraftToMove) : base(spaceCraftToMove){}

    public override void move() {}
}
