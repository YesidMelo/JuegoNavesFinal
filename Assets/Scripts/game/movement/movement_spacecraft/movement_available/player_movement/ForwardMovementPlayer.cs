using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovementPlayer : AbstractMovementSpacecraft
{
    public ForwardMovementPlayer(GameObject spaceCraftToMove) : base(spaceCraftToMove){}

    public override void move() => spaceCraftToMove.transform.Translate(0, speedSpacecraft* Time.deltaTime, 0);
    
}
