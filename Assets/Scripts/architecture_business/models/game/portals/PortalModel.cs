using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalModel
{
    public Level levelOrigin;
    public Level levelDestination;
    public float positionX = 0f;
    public float positionY = 0f;
    public float positionZ = Constants.positionPortals;

    public PortalModel(
        Level levelOrigin,
        Level levelDestination,
        float positionX,
        float positionY
    ) {
        this.levelOrigin = levelOrigin;
        this.levelDestination = levelDestination;
        this.positionX = positionX;
        this.positionY = positionY;
    }

}
