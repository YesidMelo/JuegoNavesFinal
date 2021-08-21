using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerSpacecraftMovement : MonoBehaviour
{

    public GameObject spacecraftFactory;
    public Move currentMove = Move.STOP;
    public Action currentAction = Action.DEFENSE;
    public StatusGame currentStatusGame = StatusGame.PAUSE;
    public SideSpacecraft currentSideSpacecraft = SideSpacecraft.ENEMY;
    public AbstractMovement currentMovement;

    // Start is called before the first frame update
    void Start()
    {
        initElementsGameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMovement == null) { 
            return; 
        }
        currentMovement.movement();
    }

    //private methods
    void initElementsGameObject() {
        if (currentMovement != null) { return; }
        currentMovement = (new MovementFactory()).getMovement(currentSideSpacecraft);
    }
}
