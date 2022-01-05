using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShieldPlayerEnumExtentions {

    public static long getIdDb(this ShieldPlayer currentShield) {
        switch (currentShield) {
            case ShieldPlayer.TYPE_2:
                return Constants.shieldIdDBType2;
            case ShieldPlayer.TYPE_3:
                return Constants.shieldIdDBType3;
            case ShieldPlayer.TYPE_4:
                return Constants.shieldIdDBType4;
            case ShieldPlayer.TYPE_5:
                return Constants.shieldIdDBType5;
            default:
                return Constants.shieldIdDBType1;
        }
    }

    public static ShieldPlayer getShieldPlayerByIdDB(this ShieldPlayer shieldPlayer, long? id) {
        if (id == Constants.shieldIdDBType2) return ShieldPlayer.TYPE_2;
        if (id == Constants.shieldIdDBType3) return ShieldPlayer.TYPE_3;
        if (id == Constants.shieldIdDBType4) return ShieldPlayer.TYPE_4;
        if (id == Constants.shieldIdDBType5) return ShieldPlayer.TYPE_5;
        return ShieldPlayer.TYPE_1;
    }

}