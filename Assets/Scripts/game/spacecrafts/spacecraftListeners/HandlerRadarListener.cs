using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRadarListener : HandlerRadarDelegate
{
    private AbstractSpacecraft spacecraft;

    public HandlerRadarListener(
        AbstractSpacecraft spacecraft
    ) {
        this.spacecraft = spacecraft;
    }

    public void enterGameObject(Collider2D collision)
    {
        
    }

    public void exitGameObject(Collider2D collision)
    {
        
    }
}
