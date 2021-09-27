using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingEnemy : AbstractMovementSpacecraft
{
    
    public PointingEnemy(GameObject spaceCraftToMove) : base(spaceCraftToMove){}

    public override void move()
    {
        loadEnemy();
        rotateToEnemy();
    }

    private void rotateToEnemy() {
        GameObject spaceCraft = spaceCraftToMove.transform.FindChild(Constants.nameSpacecraft).gameObject;

        if (enemy == null || currentEnemy == null) {
            spaceCraft.transform.localEulerAngles = new Vector3(0, 0, 0);
            return;
        }
        GameObject enemyToPoint = currentEnemy;
        spaceCraft.transform.eulerAngles = new Vector3(
               0,
               0,
               Functions.getAngleLookAt(
                   spaceCraft.transform.position,
                   enemyToPoint.transform.position
               )
           );
    }

}
