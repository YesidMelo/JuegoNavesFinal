using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpacecraftEnemyEnumExtentions {

    #region Laser
    public static LaserEnemy getCurrentLaser(this SpacecraftEnemy spacecraftEnemy) {
        LaserEnemy type;
        switch (spacecraftEnemy)
        {
            case SpacecraftEnemy.LIEUTENENTS:
                type = LaserEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.MAJOR:
                type = LaserEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.LIEUTENANTCOLONEL:
                type = LaserEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.COLONEL:
                type = LaserEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.SECOND_LIEUTENANTS:
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
            case SpacecraftEnemy.LIEUTENENTS:
                finalImpact = Constants.laserEnemyType2;
                break;
            case SpacecraftEnemy.MAJOR:
                finalImpact = Constants.laserEnemyType3;
                break;
            case SpacecraftEnemy.LIEUTENANTCOLONEL:
                finalImpact = Constants.laserEnemyType4;
                break;
            case SpacecraftEnemy.COLONEL:
                finalImpact = Constants.laserEnemyType5;
                break;
            default:
                finalImpact = Constants.laserEnemyType1;
                break;
        }
        return finalImpact;
    }
    #endregion

    #region life
    public static float getLife(this SpacecraftEnemy spacecraft) {
        float finalLife;
        switch (spacecraft)
        {
            case SpacecraftEnemy.LIEUTENENTS:
                finalLife = Constants.lifeEnemyStructureType2;
                break;
            case SpacecraftEnemy.MAJOR:
                finalLife = Constants.lifeEnemyStructureType3;
                break;
            case SpacecraftEnemy.LIEUTENANTCOLONEL:
                finalLife = Constants.lifeEnemyStructureType4;
                break;
            case SpacecraftEnemy.COLONEL:
                finalLife = Constants.lifeEnemyStructureType5;
                break;
            case SpacecraftEnemy.SECOND_LIEUTENANTS:
            default:
                finalLife = Constants.lifeEnemyStructureType1;
                break;
        }
        return finalLife;
    }
    #endregion

    #region shield
    public static ShieldEnemy loadCurrentShield(this SpacecraftEnemy spacecraft) {
        ShieldEnemy finalShield;
        switch (spacecraft)
        {
            case SpacecraftEnemy.LIEUTENENTS:
                finalShield = ShieldEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.MAJOR:
                finalShield = ShieldEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.LIEUTENANTCOLONEL:
                finalShield = ShieldEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.COLONEL:
                finalShield = ShieldEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.SECOND_LIEUTENANTS:
            default:
                finalShield = ShieldEnemy.TYPE_1;
                break;
        }
        return finalShield;
    }
    #endregion

    #region radar
    public static RadarEnemy loadCurrentRadar(this SpacecraftEnemy spacecraft) {
        RadarEnemy typeRadar;
        switch (spacecraft)
        {
            case SpacecraftEnemy.LIEUTENENTS:
                typeRadar = RadarEnemy.TYPE_2;
                break;
            case SpacecraftEnemy.MAJOR:
                typeRadar = RadarEnemy.TYPE_3;
                break;
            case SpacecraftEnemy.LIEUTENANTCOLONEL:
                typeRadar = RadarEnemy.TYPE_4;
                break;
            case SpacecraftEnemy.COLONEL:
                typeRadar = RadarEnemy.TYPE_5;
                break;
            case SpacecraftEnemy.SECOND_LIEUTENANTS:
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
            case SpacecraftEnemy.LIEUTENENTS:
                finalRadius = Constants.radarEnemyRadiusRadarType2;
                break;
            case SpacecraftEnemy.MAJOR:
                finalRadius = Constants.radarEnemyRadiusRadarType3;
                break;
            case SpacecraftEnemy.LIEUTENANTCOLONEL:
                finalRadius = Constants.radarEnemyRadiusRadarType4;
                break;
            case SpacecraftEnemy.COLONEL:
                finalRadius = Constants.radarEnemyRadiusRadarType5;
                break;
            case SpacecraftEnemy.SECOND_LIEUTENANTS:
            default:
                finalRadius = Constants.radarEnemyRadiusRadarType1;
                break;
        }
        return finalRadius;
    
    }
    #endregion

}