using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerMotorPlayer : MonoBehaviour, HandlerMotorPlayerViewModelDelegate
{
    public List<MotorPlayer> listMotors;
    public bool updateMotorsUI = false;

    private HandlerMotorPlayerViewModel viewModel = new HandlerMotorPlayerViewModelImpl();
    
    private BaseMotorMovementPlayer currentMovement;

    void Start()
    {
        
        viewModel.myDelegate = this;
        viewModel.setMotors(listMotors);
        viewModel.loadMotors();
    }

    // Update is called once per frame
    void Update()
    {
        updateMotorsFromUIUnity();
        move();
    }
    //public methods

    public void updateMotors(List<MotorPlayer> motor) {
        if (motor.Count == 0) return;
        if (viewModel == null) return;
        viewModel.setMotors(motor);
    }

    //private methods
    private void move() => viewModel.move();

    private bool initMovements() {
        if (currentMovement != null) return true;
        currentMovement = new MotorJoysticMovementPlayer(transform.gameObject, viewModel.speedMotor);
        return true;
    }


    //unity interaction methods

    private void updateMotorsFromUIUnity() {
        if (!updateMotorsUI) return;
        if (listMotors == null || listMotors.Count == 0) return;
        updateMotors(listMotors);
    }

    //delegate methods
    public void notifyLoadListMotors() => listMotors = viewModel.listMotors;

    public void notifyMovementAttack()
    {
        if (!initMovements()) return;
        currentMovement.move();
    }

    public void notifyMovementDefence()
    {
        if (!initMovements()) return;
        currentMovement.move();
    }

}
