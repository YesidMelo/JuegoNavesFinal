using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerSpacecraftMovement : MonoBehaviour
{

    private GameObject spacecraft;
    //-> creation
    public GameObject spacecraftFactory;
    public Spacecraft spacecraftSelected = Spacecraft.SPACECRAFT_1;

    //-> movement
    public StatusGame currentStatusGame = StatusGame.PAUSE;
    public Action currentAction = Action.STOP;
    public SideSpacecraft currentSideSpacecraft = SideSpacecraft.ENEMY;
    public AbstractMovement currentMovement;

    public AbstractSpacecraft currentSpacecraft;

    private void Awake() => createInstantanceGameobject();

    void Update() => checkMovements(); 

    //private methods

    void createInstantanceGameobject() {
        GameObject spacecraftSelected = createSpacecraftBasedInSide();
        spacecraft = Instantiate(spacecraftSelected);
        spacecraft.name = Constants.nameSpacecraft;
        spacecraft.transform.parent = transform;
        spacecraft.transform.localPosition = new Vector3(0,0,0);
        initElementsGameObject();
    }

    void checkMovements()
    {
        if (currentMovement == null) return;
        currentMovement.action = currentAction;
        currentMovement.statusGame = currentStatusGame;
        currentMovement.movement();
    }

    void initElementsGameObject() {
        if (currentMovement != null) { return; }
        currentMovement = (new MovementFactory()).getMovement(
            side: currentSideSpacecraft, 
            spacecraft: gameObject
        );
        currentMovement.myDelegate = new MovementListener(this);
    }

    GameObject createSpacecraftBasedInSide() {
        SpacecraftFactory factory = spacecraftFactory.GetComponent<SpacecraftFactory>();
        switch (currentSideSpacecraft) {
            case SideSpacecraft.PLAYER:
                return factory.spacecraftSelectedPlayer(spacecraftSelected);
            case SideSpacecraft.ENEMY:
            default:
                return factory.spacecraftSelectedGame(spacecraftSelected);
        }
    }

    
}
