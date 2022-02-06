using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LifeSupportEnumExtentions 
{
    public static long getIdDB(this LifeSupportPlayer currentLifeSupport) {
        switch (currentLifeSupport) {
            case LifeSupportPlayer.TYPE_2:
                return Constants.lifeSupportPlayerType2Id;
            case LifeSupportPlayer.TYPE_3:
                return Constants.lifeSupportPlayerType3Id;
            default:
                return Constants.lifeSupportPlayerType1Id;
        }
    }

    public static LifeSupportPlayer findLifeSupportById(this LifeSupportPlayer _, long id) {
        foreach (LifeSupportPlayer itemIndex in Enum.GetValues(typeof(LifeSupportPlayer))) {
            if (itemIndex.getIdDB() != id) continue;
            return itemIndex;
        }
        return LifeSupportPlayer.TYPE_1;
    }
}
