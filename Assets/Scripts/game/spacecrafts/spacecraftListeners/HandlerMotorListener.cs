using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerMotorListener : HandlerMotorDelegate
{
    private AbstractSpacecraft spacecraft;
    public HandlerMotorListener(
        AbstractSpacecraft spacecraft
    ) {
        this.spacecraft = spacecraft;
    }
}
