using UnityEngine;

public interface AbstractMovementDelegate {
    void updateAction(Action currentAction);
}

public abstract class AbstractMovement
{

    private StatusGame currentStatusGame;
    protected Action currentAction = Action.STOP;
    private Action previousAction = Action.STOP;
    private AbstractMovementDelegate _delegate;

    protected GameObject spacecraft;
    protected GameObject _currentEnemy;

    protected AbstractMovementSpacecraft bottomMovement;
    protected AbstractMovementSpacecraft forwardMovementEnemy;
    protected AbstractMovementSpacecraft forwardMovementPlayer;
    protected AbstractMovementSpacecraft joysticMovement;
    protected AbstractMovementSpacecraft leftMovement;
    protected AbstractMovementSpacecraft pointingEnemy;
    protected AbstractMovementSpacecraft pointingPatrol;
    protected AbstractMovementSpacecraft pointingPlayer;
    protected AbstractMovementSpacecraft restoreRotationMovement;
    protected AbstractMovementSpacecraft rigthMovement;
    protected AbstractMovementSpacecraft stopMovement;
    protected AbstractMovementSpacecraft topMovement;

    public Action action { 
        set {
            previousAction = currentAction;
            currentAction = value;
            if (_delegate == null) { return; }
            _delegate.updateAction(currentAction);
        } 
    }

    public StatusGame statusGame { set { currentStatusGame = value; } }

    public AbstractMovementDelegate myDelegate { set { _delegate = value; } }

    public AbstractMovement(
        GameObject spacecraft
    ) {
        this.spacecraft = spacecraft;
        initMovementsAvailables();
    }

    public void movement() {
        switch (currentStatusGame) {
            case StatusGame.IN_GAME:
                startMovement();
                return;
            case StatusGame.MAIN_MENU:
            case StatusGame.PAUSE:
            default:
                return;
        }
    }

    public abstract void movementAttack();
    public abstract void movementDefence();

    public abstract void movementFordward();

    public abstract void movementPatrol();

    public abstract void movementStop();
    

    void initMovementsAvailables() {
        MovementSpacecraftFactory factory = new MovementSpacecraftFactory();
        bottomMovement = factory.getMovementSpacecraft(Move.BOTTOM, spacecraft );
        forwardMovementEnemy= factory.getMovementSpacecraft(Move.FORWARD_ENEMY, spacecraft );
        forwardMovementPlayer = factory.getMovementSpacecraft(Move.FORWARD_PLAYER, spacecraft );
        joysticMovement = factory.getMovementSpacecraft(Move.JOYSTIC, spacecraft );
        leftMovement = factory.getMovementSpacecraft(Move.LEFT, spacecraft );
        pointingEnemy = factory.getMovementSpacecraft(Move.POINER_ENEMY, spacecraft );
        pointingPatrol = factory.getMovementSpacecraft(Move.POINTER_PATROL, spacecraft );
        pointingPlayer = factory.getMovementSpacecraft(Move.POINTER_PLAYER, spacecraft );
        restoreRotationMovement = factory.getMovementSpacecraft(Move.RESTORE_ROTATION, spacecraft );
        rigthMovement = factory.getMovementSpacecraft(Move.RIGT, spacecraft );
        stopMovement = factory.getMovementSpacecraft(Move.STOP, spacecraft );
        topMovement = factory.getMovementSpacecraft(Move.TOP, spacecraft );
    }

    void startMovement() {
        switch (currentAction)
        {
            case Action.ATTACK:
                movementAttack();
                return;
            case Action.CHANGE_ENEMY:
                changeEnemy();
                return;
            case Action.DEFENSE:
                movementDefence();
                return;
            case Action.FORDWARD:
                movementFordward();
                return;
            case Action.PATROL:
                movementPatrol();
                return;
            case Action.STOP:
            default:
                movementStop();
                return;
        }
    }

    void changeEnemy()
    {
        changeToPreviousAction();
        GameObject spacecraftLocal = spacecraft.transform.Find(Constants.nameSpacecraft).gameObject;
        GameObject radar = spacecraftLocal.transform.Find(Constants.nameRadar).gameObject;
        HandlerRadar handler = radar.GetComponent<HandlerRadar>();
        handler.changeEnemy();

    }

    void changeToPreviousAction()
    {

        if (previousAction != Action.CHANGE_ENEMY) { 
            action = previousAction; 
        } else { 
            currentAction = Action.ATTACK; 
        }
    }


    protected void loadEnemy()
    {
        if (spacecraft == null) {
            return;
        }
        GameObject spacecraftLocal = spacecraft.transform.Find(Constants.nameSpacecraft).gameObject;
        GameObject radar = spacecraftLocal.transform.Find(Constants.nameRadar).gameObject;
        HandlerRadar handler = radar.GetComponent<HandlerRadar>();
        _currentEnemy = handler.currentObjetive;
    }

}
