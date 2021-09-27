using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysticMovementPlayer : AbstractMovementSpacecraft
{

    private Vector3 previousDirection = new Vector3(0,0,0);
    private CurrentMovementJoysticUseCase currentMovementJoysticUseCase = new CurrentMovementJoysticUseCaseImpl();
    private ForwardMovementPlayer forwardMovementPlayer;
    private StopMovementPlayer stopMovementPlayer;

    public JoysticMovementPlayer(GameObject spaceCraftToMove) : base(spaceCraftToMove) {
        forwardMovementPlayer = new ForwardMovementPlayer(spaceCraftToMove);
        stopMovementPlayer = new StopMovementPlayer(spaceCraftToMove);
    }

    public override void move()
    {
        captureDirection();
        startFordward();
    }

    // private method
    void captureDirection() {
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
        spaceCraftToMove.transform.rotation = Quaternion.Euler(directionSpacecraft);
    }

    bool _fordward => currentMovementJoysticUseCase.invoke().x != 0 || currentMovementJoysticUseCase.invoke().y != 0;

    void startFordward()
    {
        if (_fordward)
        {
            forwardMovementPlayer.move();
            return;
        }
        stopMovementPlayer.move();
    }
}
