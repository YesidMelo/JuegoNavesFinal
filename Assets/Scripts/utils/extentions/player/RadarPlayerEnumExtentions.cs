using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RadarPlayerEnumExtentions {

    public static long getTypeRadarIdDB(this RadarPlayer currentRadar) {
        switch (currentRadar) {
            case RadarPlayer.TYPE_2:
                return 2;
            case RadarPlayer.TYPE_3:
                return 3;
            case RadarPlayer.TYPE_4:
                return 4;
            case RadarPlayer.TYPE_5:
                return 5;
            default:
                return 1;
        }
    }
}