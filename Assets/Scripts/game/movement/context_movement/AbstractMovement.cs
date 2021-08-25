using UnityEngine;

public interface AbstractMovementDelegate {
    void updateAction(Action currentAction);
    void updateMove(Move move);
}

public abstract class AbstractMovement
{

    private StatusGame currentStatusGame;
    private Action currentAction;
    private Action previousAction;
    private AbstractMovementDelegate _delegate;

    protected Move currentMove;
    protected GameObject spacecraft;

    protected AbstractMovementSpacecraft forwardMovement;
    protected AbstractMovementSpacecraft leftMovement;
    protected AbstractMovementSpacecraft pointingEnemy;
    protected AbstractMovementSpacecraft pointingPlayer;
    protected AbstractMovementSpacecraft rigthMovement;
    protected AbstractMovementSpacecraft stopMovement;

    public Action action { set { currentAction = value; } }

    public Move move { set { currentMove = value; } }
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
                changeEnemy();
                return;
            case Action.DEFENSE:
            default:
                movementDefence();
                return;
        }
    }

    void changeEnemy()
    {
        changeToPreviousAction();
        GameObject spacecraftLocal = spacecraft.transform.GetChild(0).gameObject;
        GameObject radar = spacecraftLocal.transform.FindChild(Constants.nameRadar).gameObject;
        HandlerRadar handler = radar.GetComponent<HandlerRadar>();
        if (handler.enemy.Count == 0)
        {
            return;
        }

        if (handler.currentEnemy == null || handler.enemy.Count == 1)
        {
            handler.currentEnemy = handler.enemy[0];
            return;
        }

        GameObject currentEnemy = handler.currentEnemy;
        handler.enemy.Remove(currentEnemy);
        handler.currentEnemy = handler.enemy[0];
        handler.enemy.Add(currentEnemy);

    }

    void changeToPreviousAction()
    {

        if (previousAction != null && previousAction != Action.CHANGE_ENEMY)
        {
            currentAction = previousAction;
        }
        else
        {
            currentAction = Action.ATTACK;
        }
        if (_delegate == null) {
            return;
        }
        _delegate.updateAction(currentAction);
    }

}
