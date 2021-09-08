public abstract class AbstractMotor 
{
    protected int baseSpeed = 5;
    protected int baseSpeedRotation = 10;
    public abstract int speed { get; }
    public abstract int speedRotation { get; }
}
