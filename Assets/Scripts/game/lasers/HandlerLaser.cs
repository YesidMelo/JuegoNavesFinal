using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLaserDelegate { }

public class HandlerLaser : MonoBehaviour
{
    [Range(1, 5)]
    public int maxLasers = 1;

    [Range(1, 5)]
    public int minLasers = 1;

    public List<Laser> lasersType = new List<Laser>();
    public List<AbstractLaser> lasers = new List<AbstractLaser>();
    public HandlerLaserDelegate myDelegate { set { _myDelegate = value; } }
    public int getFinalValueLaser { get { return _finalValueLaser; } }

    private HandlerLaserDelegate _myDelegate;
    private int _finalValueLaser = 0;


    void Start()
    {
        initLasersDefaults();
        calculateFinalValueLaser();
    }

    //Public methods
    public void updateLasers(List<Laser> currentLasers) {
        lasersType = currentLasers;
        initLasersDefaults();
        calculateFinalValueLaser();
    }

    // private methods
    void initLasersDefaults() {
        lasers.Clear();
        foreach (Laser currentLaser in lasersType) {
            lasers.Add((new LaserFactory()).getLaser(currentLaser));
        }
    }

    void calculateFinalValueLaser() { 

    }

}
