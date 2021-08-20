using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerStorageListener : HandlerStorageDelegate
{
    private AbstractSpacecraft spacecraft;

    public HandlerStorageListener(
        AbstractSpacecraft spacecraft
    ) {
        this.spacecraft = spacecraft;
    }
}
