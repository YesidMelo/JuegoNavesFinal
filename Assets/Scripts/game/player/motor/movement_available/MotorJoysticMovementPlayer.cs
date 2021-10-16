using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorJoysticMovementPlayer: BaseMotorMovementPlayer
{
    private GameObject _currentMotor;
    private int _speedMotor;
    private Vector3 previousDirection = new Vector3(0, 0, 0);
    private CurrentMovementJoysticUseCase currentMovementJoysticUseCase = new CurrentMovementJoysticUseCaseImpl();
    private BaseMotorMovementPlayer motorFordwardmovement;
    private BaseMotorMovementPlayer motorStopmovement;

    public MotorJoysticMovementPlayer(
        GameObject currentMotor,
        int speedMotor
    ) {
        _currentMotor = currentMotor;
        _speedMotor = speedMotor;
        motorFordwardmovement = new MotorFordwardMovementPlayer(currentMotor, speedMotor);
        motorStopmovement = new MotorStopMovementPlayer(currentMotor, speedMotor);
    }

    public void move()
    {
        captureDirection();
        startFordward();
    }

    private void captureDirection() {
        Vector2 directionJoystic = currentMovementJoysticUseCase.invoke();
        Vector3 directionSpacecraft;
        if (directionJoystic.x == 0 && directionJoystic.y == 0)
        {
            directionSpacecraft = previousDirection;
        }
        else
        {
            directionSpacecraft = new Vector3(0, 0, directionJoystic.getAngle() - 90);
            previousDirection = directionSpacecraft;
        }
        _currentMotor.transform.rotation = Quaternion.Euler(directionSpacecraft);
    }

    bool _fordward => currentMovementJoysticUseCase.invoke().x != 0 || currentMovementJoysticUseCase.invoke().y != 0;

    void startFordward()
    {
        if (_fordward)
        {
            motorFordwardmovement.move();
            return;
        }
        motorStopmovement.move();
    }
}
