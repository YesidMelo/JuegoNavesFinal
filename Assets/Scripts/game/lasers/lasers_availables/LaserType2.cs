public class LaserType2 : AbstractLaser
{
    public override float impactDamage
    {
        get => _impactDamage;
        set => _impactDamage = Constants.laserType2;
    }
}
