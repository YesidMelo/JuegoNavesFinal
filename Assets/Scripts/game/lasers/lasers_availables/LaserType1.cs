public class LaserType1 : AbstractLaser
{
    public override float impactDamage
    {
        get => _impactDamage;
        set => _impactDamage = Constants.laserType1;
    }
}
