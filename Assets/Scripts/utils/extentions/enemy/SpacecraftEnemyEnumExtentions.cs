using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpacecraftEnemyEnumExtentions {

    //laser
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

    //life
    public static float getLife(this SpacecraftEnemy spacecraft) {
        float finalLife;
        switch (spacecraft)
        {
            case SpacecraftEnemy.NIVEL1_LIEUTENENTS:
                finalLife = Constants.lifeEnemyStructureType2;
                break;
            case SpacecraftEnemy.NIVEL1_MAJOR:
                finalLife = Constants.lifeEnemyStructureType3;
                break;
            case SpacecraftEnemy.NIVEL1_LIEUTENANTCOLONEL:
                finalLife = Constants.lifeEnemyStructureType4;
                break;
            case SpacecraftEnemy.NIVEL1_COLONEL:
                finalLife = Constants.lifeEnemyStructureType5;
                break;
            case SpacecraftEnemy.NIVEL1_SECOND_LIEUTENANTS:
            default:
                finalLife = Constants.lifeEnemyStructureType1;
                break;
        }
        return finalLife;
    }

    //shield
    public static ShieldEnemy loadCurrentShield(this SpacecraftEnemy spacecraft) {
        ShieldEnemy finalShield;
        switch (spacecraft)
        {
            case SpacecraftEnemy.NIVEL1_LIEUTENENTS:
                finalShield = ShieldEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.NIVEL1_MAJOR:
                finalShield = ShieldEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.NIVEL1_LIEUTENANTCOLONEL:
                finalShield = ShieldEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.NIVEL1_COLONEL:
                finalShield = ShieldEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.NIVEL1_SECOND_LIEUTENANTS:
            default:
                finalShield = ShieldEnemy.TYPE_1;
                break;
        }
        return finalShield;
    }

    //radar
    public static RadarEnemy loadCurrentRadar(this SpacecraftEnemy spacecraft) {
        RadarEnemy typeRadar;
        switch (spacecraft)
        {
            case SpacecraftEnemy.NIVEL1_LIEUTENENTS:
                typeRadar = RadarEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.NIVEL1_MAJOR:
                typeRadar = RadarEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.NIVEL1_LIEUTENANTCOLONEL:
                typeRadar = RadarEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.NIVEL1_COLONEL:
                typeRadar = RadarEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.NIVEL1_SECOND_LIEUTENANTS:
            default:
                typeRadar = RadarEnemy.TYPE_1;
                break;
        }
        return typeRadar;
    }

    public static int loadRadiusRadar(this SpacecraftEnemy spacecraft) {
        int finalRadius;
        switch (spacecraft)
        {
            case SpacecraftEnemy.NIVEL1_LIEUTENENTS:
                finalRadius = Constants.radarEnemyRadiusRadarType2;
                break;
            case SpacecraftEnemy.NIVEL1_MAJOR:
                finalRadius = Constants.radarEnemyRadiusRadarType3;
                break;
            case SpacecraftEnemy.NIVEL1_LIEUTENANTCOLONEL:
                finalRadius = Constants.radarEnemyRadiusRadarType4;
                break;
            case SpacecraftEnemy.NIVEL1_COLONEL:
                finalRadius = Constants.radarEnemyRadiusRadarType5;
                break;
            case SpacecraftEnemy.NIVEL1_SECOND_LIEUTENANTS:
            default:
                finalRadius = Constants.radarEnemyRadiusRadarType1;
                break;
        }
        return finalRadius;
    
    }
}