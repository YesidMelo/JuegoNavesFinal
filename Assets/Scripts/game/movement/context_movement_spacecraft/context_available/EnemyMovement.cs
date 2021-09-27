using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : AbstractMovement
{

    public EnemyMovement(GameObject spacecraft) : base(spacecraft) { }


    public override void movementAttack()
    {
        loadEnemy();
        if (_currentEnemy == null) {
            action = Action.PATROL;
            return;
        }
        pointingEnemy.move();
        if (spacecraft.minimunDistance(_currentEnemy)) {
            return;
        }
        forwardMovement.move();
    }

    public override void movementDefence() => forwardMovement.move();

    public override void movementFordward() { 
        forwardMovement.move(); 
    }

    public override void movementPatrol()
    {
        loadEnemy();
        if (_currentEnemy != null) {
            action = Action.ATTACK;
            return;
        }

        string namePatrolPoint = Constants.namePatrolPoint + "_" + spacecraft.name;
        GameObject patrolPoint = GameObject.Find(namePatrolPoint);
        ///TODO(YesidMelo): Importante restaurar los puntos de patrulla para los enemigos
        
        if (patrolPoint == null) {
            return;
        }
        
        float distance = Vector3.Distance(patrolPoint.transform.position, spacecraft.transform.position);
        if (distance <= 0.06) {
            patrolPoint.changeCurrentPositionToRandom();
            return;
        }
        pointingPatrol.move();
        forwardMovement.move();
    }

    public override void movementStop() => stopMovement.move();

}