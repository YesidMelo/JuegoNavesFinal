using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerPositionBarLifePlayer : MonoBehaviour
{

    public GameObject parent;
        
    void Update()
    {
        correctionPosition();
    }

    //private methods
    private void correctionPosition() {
        if (parent == null) return;
        transform.position = parent.transform.position + Constants.distanceBetweenSpacecraftBarlife;
        transform.rotation = Quaternion.Euler(0,0,0);
    }
}
