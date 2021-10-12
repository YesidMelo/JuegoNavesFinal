using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerSpacecraftMovement : MonoBehaviour
{

    //-> creation
    public GameObject spacecraftFactory;
    public Spacecraft spacecraftSelected = Spacecraft.SPACECRAFT_1;

    //-> movement
    public StatusGame currentStatusGame = StatusGame.PAUSE;
    public Action currentAction = Action.STOP;
    public SideSpacecraft currentSideSpacecraft = SideSpacecraft.ENEMY;
    public AbstractMovement currentMovement;

    private GameObject _spacecraft;

    private void Awake() => createInstantanceGameobject();

    void Update() => checkMovements(); 

    //private methods

    void createInstantanceGameobject() {
        GameObject spacecraftSelected = createSpacecraftBasedInSide();
        _spacecraft = Instantiate(spacecraftSelected);
        _spacecraft.name = Constants.nameSpacecraft;
        _spacecraft.transform.parent = transform;
        _spacecraft.transform.localPosition = new Vector3(0,0,0);
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

    //gets and sets
    public GameObject spacecraft { 
        get => _spacecraft; 
    }
    
}
