using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerPositionLifeBarEnemy : MonoBehaviour
{
    public GameObject parent;
    private StatusGameIsGameInPauseUseCase isGameInPauseUseCase = new StatusGameIsGameInPauseUseCaseImpl();

    void Update()
    {
        if (isGameInPauseUseCase.invoke()) return;
        correctionPosition();
    }

    //private methods
    private void correctionPosition()
    {
        if (parent == null) return;
        transform.position = parent.transform.position + Constants.distanceBetweenSpacecraftBarlife;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
