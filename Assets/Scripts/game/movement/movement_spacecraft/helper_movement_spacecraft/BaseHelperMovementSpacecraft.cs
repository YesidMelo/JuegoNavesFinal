using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHelperMovementSpacecraft 
{
    protected int _speedRotationSpacecraft;
    protected int _speedSpacecraft;
    protected List<GameObject> _enemy;
    protected GameObject _currentEnemy;
    protected GameObject spaceCraftToMove;

    public BaseHelperMovementSpacecraft(GameObject spaceCraftToMove) {
        this.spaceCraftToMove = spaceCraftToMove;
    }

    public int speedRotationSpacecraft
    {
        get => _speedRotationSpacecraft;
    }

    public int speedSpacecraft
    {
        get => _speedSpacecraft;
    }

    public List<GameObject> enemy
    {
        get => _enemy;
    }

    public GameObject currentEnemy
    {
        get => _currentEnemy;
    }


    public abstract void loadSpeedSpacecraft();

    public abstract void loadEnemy();
}
