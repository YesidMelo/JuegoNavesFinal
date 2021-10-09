using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseContextBar 
{
    protected HandlerPositionBarInSpacecraft handlerPosition;
    public BaseContextBar(HandlerPositionBarInSpacecraft handlerPositionBar) {
        this.handlerPosition = handlerPositionBar;
    }
    public abstract float maxLife { get; }

    public abstract float life { get; }


}
