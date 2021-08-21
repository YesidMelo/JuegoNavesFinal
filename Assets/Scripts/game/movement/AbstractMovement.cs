public abstract class AbstractMovement 
{
    protected Move currentMove;
    protected Action currentAction;
    protected StatusGame currentStatusGame;

    public abstract void movement();

    public Move move { set { currentMove = value; } }
    public Action action { set { currentAction = value; } }
    public StatusGame current { set { currentStatusGame = value; } }
}
