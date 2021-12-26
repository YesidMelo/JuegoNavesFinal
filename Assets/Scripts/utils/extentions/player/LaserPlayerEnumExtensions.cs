using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LaserPlayerEnumExtensions {
    public static float getCurrentImpact(this LaserPlayer currentLaser) {
        switch (currentLaser)
        {
            case LaserPlayer.TYPE_2:
                return Constants.laserPlayerType2;
            case LaserPlayer.TYPE_3:
                return Constants.laserPlayerType3;
            case LaserPlayer.TYPE_4:
                return Constants.laserPlayerType4;
            case LaserPlayer.TYPE_5:
                return Constants.laserPlayerType5;
            case LaserPlayer.TYPE_1:
            default:
                return Constants.laserPlayerType1;
        }
    }

    public static LaserPlayer getCurrentLaserPlayer(this List<LaserPlayer> currentLasers) {
        float media = currentLasers.getMediaFromLasers();
        if (0 < media && media <= LaserPlayer.TYPE_1.getCurrentImpact()) {
            return LaserPlayer.TYPE_1;
        } else if (LaserPlayer.TYPE_1.getCurrentImpact() < media && media <= LaserPlayer.TYPE_2.getCurrentImpact()) {
            return LaserPlayer.TYPE_2;
        } else if (LaserPlayer.TYPE_2.getCurrentImpact() < media && media <= LaserPlayer.TYPE_3.getCurrentImpact()) {
            return LaserPlayer.TYPE_3;
        } else if (LaserPlayer.TYPE_3.getCurrentImpact() < media && media <= LaserPlayer.TYPE_4.getCurrentImpact()) {
            return LaserPlayer.TYPE_4;
        }
        return LaserPlayer.TYPE_5;
    }

    public static float getMediaFromLasers(this List<LaserPlayer> currentLasers) {
        float totalLaser = 0;
        foreach (LaserPlayer currentLaser in currentLasers) {
            totalLaser += currentLaser.getCurrentImpact();
        }
        return totalLaser / currentLasers.Count;
    }

    public static long getIdDB(this LaserPlayer currentLaser) {
        switch (currentLaser) {
            case LaserPlayer.TYPE_2:
                return 2;
            case LaserPlayer.TYPE_3:
                return 3;
            case LaserPlayer.TYPE_4:
                return 4;
            case LaserPlayer.TYPE_5:
                return 5;
            default:
                return 1;
        }
    }
}