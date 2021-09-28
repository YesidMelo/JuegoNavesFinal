using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextLaserEnemy : BaseContextLaser
{
    public ContextLaserEnemy(
        List<AbstractLaser> lasers, 
        List<Laser> lasersType,
        BaseContextLaserDelegate myDelegate
    ) : base(lasers, lasersType, myDelegate){}

    public override void calculateFinalValueLaser()
    {
        
    }

    public override void initLasersDefaults()
    {
        
    }

    public override void shoot()
    {
        
    }

    public override void updateLasers(List<Laser> currentLasers)
    {
        
    }
}
