using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseContextLaserDelegate
{
    void startCorutine();
}

public abstract class BaseContextLaser 
{
    protected List<AbstractLaser> _lasers = new List<AbstractLaser>();
    protected List<Laser> _lasersType = new List<Laser>();
    protected IEnumerator corutineShoot;
    protected AbstractLaser _finalLaser;
    protected GameObject _gameObject;

    protected bool _shooting = false;
    protected BaseContextLaserDelegate myDelegate;

    public BaseContextLaser(
        List<AbstractLaser> lasers,
        List<Laser> lasersType,
        BaseContextLaserDelegate myDelegate,
        GameObject gameObject
    ) {
        this._lasers = lasers;
        this._lasersType = lasersType;
        this.myDelegate = myDelegate;
        this._gameObject = gameObject;
    }

    // Abstracts
    //->public methods 
    public abstract void initLasersDefaults();
    public abstract void calculateFinalValueLaser();
    public abstract void updateLasers(List<Laser> currentLasers);
    public abstract void shoot();

    // Concretes
    // protected methods
    protected AbstractLaser generateLaser(Laser laser)
    {
        switch (laser)
        {
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

    //sets and gets
    public bool shooting {
        get => _shooting;
    }

    public List<AbstractLaser> lasers {
        get => _lasers;
    }

    public List<Laser> lasersType {
        get => _lasersType;
    }

    public AbstractLaser finalLaser {
        get => _finalLaser;
    }

}
