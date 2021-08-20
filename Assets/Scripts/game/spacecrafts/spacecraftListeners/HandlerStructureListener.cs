using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerStructureListener : HandlerStructureDelegate
{
    private AbstractSpacecraft spacecraft;

    public HandlerStructureListener(
        AbstractSpacecraft spacecraft
    ) {
        this.spacecraft = spacecraft;
    }

}
