using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigthMovement : AbstractMovementSpacecraft
{
    public RigthMovement(GameObject spaceCraftToMove) : base(spaceCraftToMove){}

    public override void move() => spaceCraftToMove.transform.Translate(speedSpacecraft * Time.deltaTime, 0, 0);
}
