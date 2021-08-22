using UnityEngine;

public abstract class AbstractMovement 
{
    
    private StatusGame currentStatusGame;
    private Action previousAction;
    private Action currentAction;

    protected Move currentMove;
    protected GameObject spacecraft;

    protected AbstractMovementSpacecraft forwardMovement;
    protected AbstractMovementSpacecraft leftMovement;
    protected AbstractMovementSpacecraft pointingEnemy;
    protected AbstractMovementSpacecraft pointingPlayer;
    protected AbstractMovementSpacecraft rigthMovement;
    protected AbstractMovementSpacecraft stopMovement;

    public Action action
    {
        set
        {
            previousAction = currentAction;
            currentAction = value;
        }
    }

    public Move move { set { currentMove = value; } }
    public StatusGame statusGame { set { currentStatusGame = value; } }

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
    public abstract void movementChangeEnemy();

    void initMovementsAvailables() {
        MovementSpacecraftFactory factory = new MovementSpacecraftFactory();
        forwardMovement = factory.getMovementSpacecraft(Move.FORWARD, spacecraft );
        leftMovement = factory.getMovementSpacecraft(Move.LEFT, spacecraft );
        pointingEnemy = factory.getMovementSpacecraft(Move.POINER_ENEMY, spacecraft );
        pointingPlayer = factory.getMovementSpacecraft(Move.POINTER_PLAYER, spacecraft );
        rigthMovement = factory.getMovementSpacecraft(Move.RIGT, spacecraft );
        stopMovement = factory.getMovementSpacecraft(Move.STOP, spacecraft );
    }

    void startMovement() {
        switch (currentAction)
        {
            case Action.ATTACK:
                movementAttack();
                return;
            case Action.CHANGE_ENEMY:
                movementChangeEnemy();
                return;
            case Action.DEFENSE:
            default:
                movementDefence();
                return;
        }
    }
   
}
