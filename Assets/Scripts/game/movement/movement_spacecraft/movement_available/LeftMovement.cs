using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : AbstractMovementSpacecraft
{
    public LeftMovement(GameObject spaceCraftToMove) : base(spaceCraftToMove){}

    //public override void move() => spaceCraftToMove.transform.Translate(-speedSpacecraft * Time.deltaTime, 0, 0);
    public override void move() => spaceCraftToMove.transform.Rotate(0, 0, speedRotationSpacecraft * Time.deltaTime * 10);


}
