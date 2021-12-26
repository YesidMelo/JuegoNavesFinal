using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShieldPlayerEnumExtentions {

    public static long getIdDb(this ShieldPlayer currentShield) {
        switch (currentShield) {
            case ShieldPlayer.TYPE_2:
                return 2;
            case ShieldPlayer.TYPE_3:
                return 3;
            case ShieldPlayer.TYPE_4:
                return 4;
            case ShieldPlayer.TYPE_5:
                return 5;
            default:
                return 1;
        }
    }

}