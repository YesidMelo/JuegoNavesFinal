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
    public static string nameLaserWeapon = "laser";

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
    public static float speedLaser = 100.0f;
    public static float speedFiring = 0.1f;

    //life bar
    public static Vector3 distanceBetweenSpacecraftBarlife = new Vector3(0,1.4f,0);

}
