using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextLaserEnemy : BaseContextLaser
{
    public ContextLaserEnemy(
        List<AbstractLaser> lasers, 
        List<Laser> lasersType,
        BaseContextLaserDelegate myDelegate,
        GameObject gameObject
    ) : base(lasers, lasersType, myDelegate, gameObject){}

    public override void calculateFinalValueLaser()
    {
        if (lasersType == null || lasersType.Count == 0) return;
        float finalValue = 0;
        for (int index = 0; index < lasersType.Count; index++)
        {
            AbstractLaser currentLaser = generateLaser(lasersType[index]);
            finalValue = finalValue + currentLaser.impactDamage;
        }
        _finalLaser = new LaserFinal();
        _finalLaser.impactDamage = finalValue;
    }

    public override void initLasersDefaults()
    {
        _lasers.Clear();
        foreach (Laser currentLaser in lasersType)
        {
            _lasers.Add((new LaserFactory()).getLaser(currentLaser));
        }
    }

    public override void shoot() {
        if (!IHaveEnemiesNearby()) {
            _shooting = false;
            return; 
        }
        if (shooting) return;
        _shooting = true;
        if (myDelegate == null) return;
        myDelegate.startCorutine();
    }

    public override void updateLasers(List<Laser> currentLasers)
    {
        _lasersType = currentLasers;
        initLasersDefaults();
        calculateFinalValueLaser();
    }

    //private methods
    private bool IHaveEnemiesNearby() {
        GameObject parent = _gameObject.transform.parent.gameObject;
        GameObject radar = parent.transform.FindChild(Constants.nameRadar).gameObject;

        if (radar == null) return false;
        HandlerRadar handler = radar.GetComponent<HandlerRadar>();
        if (handler == null) return false;
        if (handler.currentObjetive == null) return false;
        Transform parentCurrrentObjetiveRadar = handler.currentObjetive.transform.parent;
        if (parentCurrrentObjetiveRadar == null) return false;
        Transform grandParentCurrentObjetiveRadar = parentCurrrentObjetiveRadar.transform.parent;
        if (grandParentCurrentObjetiveRadar == null) return false;
        if (!grandParentCurrentObjetiveRadar.name.Contains(Constants.namePlayer)) return false;
        return true;
    }
}
