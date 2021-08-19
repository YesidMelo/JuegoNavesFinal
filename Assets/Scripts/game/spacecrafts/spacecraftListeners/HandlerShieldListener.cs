using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerShieldListener : HanderShieldDelegate
{
    private AbstractSpacecraft spacecraft;

    public HandlerShieldListener(
        AbstractSpacecraft spacecraft
    ) {
        this.spacecraft = spacecraft;
    }

    public void impactGoneShield()
    {
        
    }

    public void impactIncomeShield()
    {
        
    }
}
