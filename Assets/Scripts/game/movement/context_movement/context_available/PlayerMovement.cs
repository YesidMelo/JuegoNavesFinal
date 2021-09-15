using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbstractMovement
{
    
    private CurrentMovementJoysticUseCase currentMovementJoysticUseCase = new CurrentMovementJoysticUseCaseImpl();

    public PlayerMovement(GameObject spacecraft) : base(spacecraft) {}

    public override void movementAttack()
    {
        rotateSpacecraftInDirectionJoyistic();
    }

    public override void movementDefence() {
        rotateSpacecraftInDirectionJoyistic();
    }

    public override void movementFordward() {
        forwardMovement.move();
        rotateSpacecraftInDirectionJoyistic();
    }

    public override void movementPatrol() => action = Action.ATTACK;

    public override void movementStop() {
        stopMovement.move(); 
        rotateSpacecraftInDirectionJoyistic();
    }


    // private methods
    private void rotateSpacecraftInDirectionJoyistic() {
        Vector2 directionJoystic = currentMovementJoysticUseCase.invoke();
        Vector3 directionSpacecraft;
        if (directionJoystic.x == 0 && directionJoystic.y == 0)
        {
            directionSpacecraft = new Vector3(0, 0, directionJoystic.getAngle());
        }
        else {
            directionSpacecraft = new Vector3(0, 0, directionJoystic.getAngle() - 90);
        }
        spacecraft.transform.rotation = Quaternion.Euler(directionSpacecraft);
    }

  
}