
public class LaserFactory 
{
    public AbstractLaser getLaser(Laser laserSelected) {
        switch (laserSelected) {
            case Laser.TYPE_2:
                return new LaserType2();
            case Laser.TYPE_3:
                return new LaserType3();
            case Laser.TYPE_4:
                return new LaserType4();
            case Laser.TYPE_5:
                return new LaserType5();
            case Laser.TYPE_1:
            default:
                return new LaserType1();
        }
    }
}
