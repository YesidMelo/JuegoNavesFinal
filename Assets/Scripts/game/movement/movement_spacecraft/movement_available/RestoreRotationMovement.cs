using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreRotationMovement : AbstractMovementSpacecraft
{
    public RestoreRotationMovement(GameObject spaceCraftToMove) : base(spaceCraftToMove) { }

    public override void move() {
        GameObject spaceCraft = spaceCraftToMove.transform.FindChild(Constants.nameSpacecraft).gameObject;
        spaceCraft.transform.localEulerAngles = new Vector3(0,0,0);
    }
}
