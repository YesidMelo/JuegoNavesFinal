using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerMovementEnemy : MonoBehaviour, HandlerMovementEnemyViewModelDelegate
{
    public HandlerMotorsEnemy handlerMotor;
    public List<GameObject> listGameObjects;
    public GameObject currentPlayer;
    public GameObject spacecraft;

    private HandlerMovementEnemyViewModel viewModel = new HandlerMovementEnemyViewModelImpl();

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
        pointToPatrolPoint();
    }

    private void moveForwardPlayer() {
        float distance = Vector3.Distance(spacecraft.transform.position, currentPlayer.transform.position);
        if (distance <= Constants.minimunDistaceBetweenPlayerEnemy) return;
        spacecraft.transform.Translate(Vector3.up * Time.deltaTime * handlerMotor.currentSpeed, Space.Self); 
    }

    private void pointToPlayer() {
        Vector2 positionSpacecraft = new Vector2(spacecraft.transform.position.x, spacecraft.transform.position.y);
        Vector2 positionPlayer = new Vector2(currentPlayer.transform.position.x, currentPlayer.transform.position.y);
        spacecraft.transform.rotation = Quaternion.Euler(0,0, Functions.getAngleLookAt(positionSpacecraft, positionPlayer) );
    }

    private void pointToPatrolPoint() { 

    }
}
