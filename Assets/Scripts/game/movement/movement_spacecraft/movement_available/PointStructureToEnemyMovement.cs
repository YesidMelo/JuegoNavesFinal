using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointStructureToEnemyMovement : AbstractMovementSpacecraft
{
    public PointStructureToEnemyMovement(GameObject spaceCraftToMove) : base(spaceCraftToMove) {}

    public override void move()
    {
        loadEnemy();
        rotateToEnemy();
    }

    private void rotateToEnemy()
    {
        if (enemy == null || currentEnemy == null) return;

        GameObject spaceCraft = spaceCraftToMove.transform.GetChild(0).gameObject;
        
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
