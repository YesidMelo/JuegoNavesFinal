using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingPatrol : AbstractMovementSpacecraft
{
    public PointingPatrol(GameObject spaceCraftToMove) : base(spaceCraftToMove){}

    public override void move()
    {
        GameObject spaceCraft = spaceCraftToMove.transform.GetChild(0).gameObject;
        string namePointPatrol = Constants.namePatrolPoint+ "_" + spaceCraftToMove.transform.name;
        GameObject patrolPoint = GameObject.Find(namePointPatrol);

        spaceCraftToMove.transform.eulerAngles = new Vector3(
               0,
               0,
               Functions.getAngleLookAt(
                   spaceCraft.transform.position,
                   patrolPoint.transform.position
               )
           );
    }
}
