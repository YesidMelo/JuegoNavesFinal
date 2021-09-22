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
    private CurrentActionSpacecraftUseCase _currentActionSpacecraftUseCase = new CurrentActionSpacecraftUseCaseImpl();


    void Start()
    {
        initLasersDefaults();
        calculateFinalValueLaser();
    }

    private void Update()
    {
        checkShoot();
    }

    //Public methods
    public void updateLasers(List<Laser> currentLasers) {
        lasersType = currentLasers;
        initLasersDefaults();
        calculateFinalValueLaser();
    }

    // private methods
    private void initLasersDefaults() {
        lasers.Clear();
        foreach (Laser currentLaser in lasersType) {
            lasers.Add((new LaserFactory()).getLaser(currentLaser));
        }
    }

    private void calculateFinalValueLaser() { 

    }

    private void checkShoot() {
        switch (_currentActionSpacecraftUseCase.invoke()) {
            case Action.ATTACK:
                shoot();
                return;
            default:
                return;
        }
    }

    private void shoot() {
        GameObject parent = transform.parent.gameObject;
        GameObject spacecraft = parent.transform.FindChild(Constants.nameSpacecraft).gameObject;
    }

}
