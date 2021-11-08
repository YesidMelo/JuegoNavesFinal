using UnityEngine;

public static class Constants 
{
    //Strings
    public static string nameCameraPlayer = "camera_player";
    
    public static string nameSpacecraft = "spacecraft";
    public static string namePatrolPoint = "patrolPoint";
    public static string nameAmmunitionLaserEnemy = "ammunitionLaserEnemy";

    //strings enemy
    public static string nameAmmunitionLaserPlayer = "ammunitionLaserPlayer";
    public static string nameEnemy = "enemy";
    public static string nameLaserEnemy = "laserEnemy";
    public static string nameRadarEnemy = "radarEnemy";
    public static string nameShieldEnemy = "shieldEnemy";

    //strings player
    public static string nameMotorPlayer = "motorPlayer";
    public static string nameLaserPlayer = "laserPlayer";
    public static string namePlayer = "player";
    public static string nameRadarPlayer = "radarPlayer";

    //Distance
    public static float minimunDistaceBetweenPlayerEnemy = 3f;

    //Dimension
    public static float safeAreaHeigth = 480;
    public static float safeAreaWidth = 800;
    public static float dimensionHeightBackground = 100;
    public static float dimensionWidthBackground = 100;

    //impact damage laser player
    public static float laserPlayerType1 = 10;
    public static float laserPlayerType2 = 20;
    public static float laserPlayerType3 = 30;
    public static float laserPlayerType4 = 40;
    public static float laserPlayerType5 = 50;

    //impact damage laser enemy
    public static int laserEnemyType1 = 10;
    public static int laserEnemyType2 = 20;
    public static int laserEnemyType3 = 30;
    public static int laserEnemyType4 = 40;
    public static int laserEnemyType5 = 50;

    //speeds
    public static float speedLaser = 25.0f;
    public static float speedFiring = 1f;

    //Speeds enemy spacecraft
    public static float speedMotorEnemyType1 = 1f;
    public static float speedMotorEnemyType2 = 1.5f;
    public static float speedMotorEnemyType3 = 2f;
    public static float speedMotorEnemyType4 = 2.5f;
    public static float speedMotorEnemyType5 = 3f;
    
    //Speeds player spacecraft
    public static float speedMotorPlayerType1 = 1f;
    public static float speedMotorPlayerType2 = 1.5f;
    public static float speedMotorPlayerType3 = 2;
    public static float speedMotorPlayerType4 = 2.5f;
    public static float speedMotorPlayerType5 = 3f;

    //LifeEnemy
    public static float lifeEnemyStructureType1 = 500;
    public static float lifeEnemyStructureType2 = 1000;
    public static float lifeEnemyStructureType3 = 1500;
    public static float lifeEnemyStructureType4 = 2000;
    public static float lifeEnemyStructureType5 = 2500;

    //LifePlayer
    public static int lifePlayerStructureType1 = 500;
    public static int lifePlayerStructureType2 = 1000;
    public static int lifePlayerStructureType3 = 1500;
    public static int lifePlayerStructureType4 = 2000;
    public static int lifePlayerStructureType5 = 2500;

    //life bar player
    public static float lifeBarPlayer = 0.3f;
    public static Vector3 distanceBetweenSpacecraftBarlife = new Vector3(0,1.4f,0);

    //RadarEnemy
    public static int radarEnemyRadiusRadarType1 = 5;
    public static int radarEnemyRadiusRadarType2 = 5;
    public static int radarEnemyRadiusRadarType3 = 5;
    public static int radarEnemyRadiusRadarType4 = 5;
    public static int radarEnemyRadiusRadarType5 = 5;
    
    //RadarPlayer
    public static float radarPlayerRadiusRadarType1 = 5f;
    public static float radarPlayerRadiusRadarType2 = 5.5f;
    public static float radarPlayerRadiusRadarType3 = 6f;
    public static float radarPlayerRadiusRadarType4 = 6.5f;
    public static float radarPlayerRadiusRadarType5 = 7f;

}
