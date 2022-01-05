using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RadarPlayerEnumExtentions {

    public static long getTypeRadarIdDB(this RadarPlayer currentRadar) {
        switch (currentRadar) {
            case RadarPlayer.TYPE_2:
                return Constants.radarPlayerIdDBType2;
            case RadarPlayer.TYPE_3:
                return Constants.radarPlayerIdDBType3;
            case RadarPlayer.TYPE_4:
                return Constants.radarPlayerIdDBType4;
            case RadarPlayer.TYPE_5:
                return Constants.radarPlayerIdDBType5;
            default:
                return Constants.radarPlayerIdDBType1;
        }
    }

    public static RadarPlayer getTypeRadarByIdDB(this RadarPlayer currentRadar, long? id)
    {
        if (id == Constants.radarPlayerIdDBType2) return RadarPlayer.TYPE_2;
        if (id == Constants.radarPlayerIdDBType3) return RadarPlayer.TYPE_3;
        if (id == Constants.radarPlayerIdDBType4) return RadarPlayer.TYPE_4;
        if (id == Constants.radarPlayerIdDBType5) return RadarPlayer.TYPE_5;
        return RadarPlayer.TYPE_1;
    }
}