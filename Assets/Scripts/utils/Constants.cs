using UnityEngine;

public static class Constants 
{
    //Strings
    public static string nameCameraPlayer = "camera_player";
    public static string nameEnemy = "enemy";
    public static string nameMotor = "motor";
    public static string namePlayer = "player";
    public static string nameRadar = "radar";
    public static string nameSpacecraft = "spacecraft";
    public static string namePatrolPoint = "patrolPoint";
    public static string nameAmmunitionLaserPlayer = "ammunitionLaserPlayer";
    public static string nameAmmunitionLaserEnemy = "ammunitionLaserEnemy";

    //Distance
    public static float minimunDistaceBetweenPlayerEnemy = 5f;

    //Dimension
    public static float safeAreaHeigth = 480;
    public static float safeAreaWidth = 800;
    public static float dimensionHeightBackground = 100;
    public static float dimensionWidthBackground = 100;

    //impact damage laser
    public static float laserType1 = 10;
    public static float laserType2 = 20;
    public static float laserType3 = 30;
    public static float laserType4 = 40;
    public static float laserType5 = 50;

    //speeds
    public static float speedLaser = 25.0f;
    public static float speedFiring = 3f;

    //Speeds player spacecraft
    public static int speedMotorPlayerType1 = 5;
    public static int speedMotorPlayerType2 = 6;
    public static int speedMotorPlayerType3 = 7;
    public static int speedMotorPlayerType4 = 8;
    public static int speedMotorPlayerType5 = 9;

    //LifePlayer
    public static int lifePlayerStructureType1 = 500;
    public static int lifePlayerStructureType2 = 1000;
    public static int lifePlayerStructureType3 = 1500;
    public static int lifePlayerStructureType4 = 2000;
    public static int lifePlayerStructureType5 = 2500;

    //life bar player
    public static float lifeBarPlayer = 0.3f;
    public static Vector3 distanceBetweenSpacecraftBarlife = new Vector3(0,1.4f,0);

    //RadarPlayer
    public static float radarPlayerRadiusRadarType1 = 5f;
    public static float radarPlayerRadiusRadarType2 = 5.5f;
    public static float radarPlayerRadiusRadarType3 = 6f;
    public static float radarPlayerRadiusRadarType4 = 6.5f;
    public static float radarPlayerRadiusRadarType5 = 7f;

}
