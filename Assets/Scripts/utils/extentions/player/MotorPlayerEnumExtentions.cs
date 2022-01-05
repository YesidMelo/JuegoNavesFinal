using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MotorPlayerEnumExtentions 
{
    public static long getTyperMotorIdDB(this MotorPlayer currentMotor) {
        switch (currentMotor) {
            case MotorPlayer.TYPE_2:
                return Constants.motorIdDBType2;
            case MotorPlayer.TYPE_3:
                return Constants.motorIdDBType3;
            case MotorPlayer.TYPE_4:
                return Constants.motorIdDBType4;
            case MotorPlayer.TYPE_5:
                return Constants.motorIdDBType5;
            default:
                return Constants.idMotorDbType1;
        }
    }

    public static MotorPlayer getTypeMotorPlayerById(this MotorPlayer currentPlayer, long? id) {
        if (id == Constants.motorIdDBType2) return MotorPlayer.TYPE_2;
        if (id == Constants.motorIdDBType3) return MotorPlayer.TYPE_3;
        if (id == Constants.motorIdDBType4) return MotorPlayer.TYPE_4;
        if (id == Constants.motorIdDBType5) return MotorPlayer.TYPE_5;
        return MotorPlayer.TYPE_1;
    }
}
