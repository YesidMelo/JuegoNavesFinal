using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpacecraftEnemyEnumExtentions {

    public static LaserEnemy getCurrentLaser(this SpacecraftEnemy spacecraftEnemy) {
        LaserEnemy type;
        switch (spacecraftEnemy)
        {
            case SpacecraftEnemy.NIVEL1_LIEUTENENTS:
                type = LaserEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.NIVEL1_MAJOR:
                type = LaserEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.NIVEL1_LIEUTENANTCOLONEL:
                type = LaserEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.NIVEL1_COLONEL:
                type = LaserEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.NIVEL1_SECOND_LIEUTENANTS:
            default:
                type = LaserEnemy.TYPE_1;
                break;
        }
        return type;
    }

    public static int getImpactLaser(this SpacecraftEnemy spacecraftEnemy) {
        int finalImpact;
        switch (spacecraftEnemy)
        {
            case SpacecraftEnemy.NIVEL1_LIEUTENENTS:
                finalImpact = Constants.laserEnemyType2;
                break;
            case SpacecraftEnemy.NIVEL1_MAJOR:
                finalImpact = Constants.laserEnemyType3;
                break;
            case SpacecraftEnemy.NIVEL1_LIEUTENANTCOLONEL:
                finalImpact = Constants.laserEnemyType4;
                break;
            case SpacecraftEnemy.NIVEL1_COLONEL:
                finalImpact = Constants.laserEnemyType5;
                break;
            default:
                finalImpact = Constants.laserEnemyType1;
                break;
        }
        return finalImpact;
    }

}