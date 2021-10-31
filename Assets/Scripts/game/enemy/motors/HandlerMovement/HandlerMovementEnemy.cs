using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerMovementEnemy : MonoBehaviour, HandlerMovementEnemyViewModelDelegate
{
    public HandlerMotorsEnemy handlerMotor;
    public List<GameObject> listGameObjects;
    public GameObject currentPlayer;
    public GameObject spacecraft;
    public GameObject prefabPatrolPoint;

    private HandlerMovementEnemyViewModel viewModel = new HandlerMovementEnemyViewModelImpl();
    private GameObject patrolPoint;

    private void Awake()
    {
        viewModel.myDelegate = this;
    }


    // Update is called once per frame
    void Update()
    {
        checkCurrentElementsInRadar();
        moveSpacecraft();
    }

    //private methods
    private void checkCurrentElementsInRadar() {
        if (handlerMotor == null) return;
        if (handlerMotor.identificator == null) return;
        if (viewModel == null) return;
        listGameObjects = viewModel.currentGameobjects;
        currentPlayer = viewModel.currentPlayer(handlerMotor.identificator);
    }

    private void moveSpacecraft() {
        if (handlerMotor == null) return;
        if (currentPlayer != null) {
            moveForwardPlayer();
            pointToPlayer();
            return;
        }
        if (patrolPoint == null) {
            createPatrolPoint();
            return;
        }
        pointToPatrolPoint();
        moveForwardPatrolPoint();
    }

    private void changePositionPatrolPoint() {
        patrolPoint.transform.position = new Vector3(
            Functions.generateRandomNumberBetween(-Constants.dimensionWidthBackground, Constants.dimensionWidthBackground),
            Functions.generateRandomNumberBetween(-Constants.dimensionHeightBackground, Constants.dimensionHeightBackground),
            0
        );
    }

    private void createPatrolPoint() {
        patrolPoint = Instantiate(prefabPatrolPoint);
        changePositionPatrolPoint();
    }

    private void moveForwardPlayer() {
        float distance = Vector3.Distance(spacecraft.transform.position, currentPlayer.transform.position);
        if (distance <= Constants.minimunDistaceBetweenPlayerEnemy) return;
        spacecraft.transform.Translate(Vector3.up * Time.deltaTime * handlerMotor.currentSpeed, Space.Self); 
    }
    

    private void moveForwardPatrolPoint() {
        float distance = Vector3.Distance(spacecraft.transform.position, patrolPoint.transform.position);
        if (distance <= Constants.minimunDistaceBetweenPlayerEnemy) {
            changePositionPatrolPoint();
            return;
        }
        spacecraft.transform.Translate(Vector3.up * Time.deltaTime * handlerMotor.currentSpeed, Space.Self); 
    }

    private void pointToPlayer() {
        Vector2 positionSpacecraft = new Vector2(spacecraft.transform.position.x, spacecraft.transform.position.y);
        Vector2 positionPlayer = new Vector2(currentPlayer.transform.position.x, currentPlayer.transform.position.y);
        spacecraft.transform.rotation = Quaternion.Euler(0,0, Functions.getAngleLookAt(positionSpacecraft, positionPlayer) );
    }

    private void pointToPatrolPoint() {
        Vector2 positionSpacecraft = new Vector2(spacecraft.transform.position.x, spacecraft.transform.position.y);
        Vector2 positionPatrolPoint = new Vector2(patrolPoint.transform.position.x, patrolPoint.transform.position.y);
        spacecraft.transform.rotation = Quaternion.Euler(0, 0, Functions.getAngleLookAt(positionSpacecraft, positionPatrolPoint));
    }
}
