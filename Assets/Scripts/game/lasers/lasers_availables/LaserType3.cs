public class LaserType3 : AbstractLaser
{
    public override float impactDamage
    {
        get => _impactDamage;
        set => _impactDamage = Constants.laserType3;
    }
}
