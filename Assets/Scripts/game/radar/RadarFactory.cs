using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarFactory {

    public AbstractRadar getRadar(Radar radar) {
        switch (radar) {
            case Radar.TYPE_2:
                return new RadarType2();
            case Radar.TYPE_3:
                return new RadarType3();
            case Radar.TYPE_4:
                return new RadarType4();
            case Radar.TYPE_5:
                return new RadarType5();
            case Radar.TYPE_1:
            default:
                return new RadarType1();
        }
    }
}