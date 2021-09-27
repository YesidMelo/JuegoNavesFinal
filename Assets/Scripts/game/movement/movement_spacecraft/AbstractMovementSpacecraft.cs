using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovementSpacecraft 
{
    protected GameObject spaceCraftToMove;
    private BaseHelperMovementSpacecraft _contextMovement;

    protected int speedRotationSpacecraft {
        get => _contextMovement != null ? _contextMovement.speedRotationSpacecraft : 1;
    }

    protected int speedSpacecraft { 
        get => _contextMovement != null ? _contextMovement.speedSpacecraft : 1;
    }

    protected List<GameObject> enemy {
        get => _contextMovement != null ? _contextMovement.enemy : new List<GameObject>();
    }

    protected GameObject currentEnemy
    {
        get => _contextMovement != null ? _contextMovement.currentEnemy : null;
    }

    public AbstractMovementSpacecraft(
        GameObject spaceCraftToMove
    ) {
        this.spaceCraftToMove = spaceCraftToMove;
        selectContextMovement();
        loadSpeedSpacecraft();
    }

    public abstract void move();

    protected void loadEnemy() {
        if (_contextMovement == null) return;
        _contextMovement.loadEnemy();
    }

    private void loadSpeedSpacecraft() {
        if (_contextMovement == null) return;
        _contextMovement.loadSpeedSpacecraft();
    }

    private void selectContextMovement() {
        if (spaceCraftToMove.name.Contains(Constants.nameEnemy)) {
            _contextMovement = new HelperMovementEnemy(spaceCraftToMove);
            return;
        }
        _contextMovement = new HelperMovementPlayer(spaceCraftToMove);
    }

}
