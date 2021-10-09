using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextLaserPlayer : BaseContextLaser
{
    private CurrentActionSpacecraftUseCase _currentActionSpacecraftUseCase = new CurrentActionSpacecraftUseCaseImpl();

    public ContextLaserPlayer (
        List<AbstractLaser> lasers, 
        List<Laser> lasersType,
        BaseContextLaserDelegate myDelegate,
        GameObject gameObject
    ) : base(lasers, lasersType, myDelegate,gameObject){}

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
        _finalLaser.nameParent = _gameObject.transform.parent.parent.name;
    }

    public override void initLasersDefaults()
    {
        _lasers.Clear();
        foreach (Laser currentLaser in lasersType)
        {
            _lasers.Add((new LaserFactory()).getLaser(currentLaser));
        }
    }

    public override void shoot()
    {
        if (_currentActionSpacecraftUseCase.invoke() != Action.ATTACK)
        {
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
}
