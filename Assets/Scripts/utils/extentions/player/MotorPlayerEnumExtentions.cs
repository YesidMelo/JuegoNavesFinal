using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MotorPlayerEnumExtentions 
{
    public static long getTyperMotorIdDB(this MotorPlayer currentMotor) {
        switch (currentMotor) {
            case MotorPlayer.TYPE_2:
                return 2;
            case MotorPlayer.TYPE_3:
                return 3;
            case MotorPlayer.TYPE_4:
                return 4;
            case MotorPlayer.TYPE_5:
                return 5;
            default:
                return 1;
        }
    }
}
