using UnityEngine;

public static class Constants 
{
    //region AllStrings
    //Strings
    public static string nameCameraPlayer = "camera_player";
    
    public static string nameSpacecraft = "spacecraft";
    public static string namePatrolPoint = "patrolPoint";

    //strings enemy
    public static string nameEnemyCapital = "Enemy";
    public static string nameAmmunitionLaserEnemy = "ammunitionLaserEnemy";
    public static string nameEnemy = "enemy";
    public static string nameLaserEnemy = "laserEnemy";
    public static string nameRadarEnemy = "radarEnemy";
    public static string nameShieldEnemy = "shieldEnemy";

    //strings player
    public static string nameAmmunitionLaserPlayer = "ammunitionLaserPlayer";
    public static string nameMotorPlayer = "motorPlayer";
    public static string nameLaserPlayer = "laserPlayer";
    public static string namePlayer = "player";
    public static string namePlayerCapital = "Player";
    public static string nameRadarPlayer = "radarPlayer";
    public static string nameShieldPlayer = "shieldPlayer";

    //string spawmer poblation
    public static string nameSpawmerPoblation = "spawmerPoblation";

    //endregion

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
    public static float speedMotorEnemyType1 = 2f;
    public static float speedMotorEnemyType2 = 2.5f;
    public static float speedMotorEnemyType3 = 3f;
    public static float speedMotorEnemyType4 = 3.5f;
    public static float speedMotorEnemyType5 = 4f;
    
    //Speeds player spacecraft
    public static float speedMotorPlayerType1 = 2f;
    public static float speedMotorPlayerType2 = 2.5f;
    public static float speedMotorPlayerType3 = 3;
    public static float speedMotorPlayerType4 = 3.5f;
    public static float speedMotorPlayerType5 = 4f;

    //LifeEnemy
    public static float lifeEnemyStructureType1 = 100;
    public static float lifeEnemyStructureType2 = 200;
    public static float lifeEnemyStructureType3 = 300;
    public static float lifeEnemyStructureType4 = 400;
    public static float lifeEnemyStructureType5 = 500;

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
    public static int radarEnemyRadiusRadarType1 = 10;
    public static int radarEnemyRadiusRadarType2 = 10;
    public static int radarEnemyRadiusRadarType3 = 10;
    public static int radarEnemyRadiusRadarType4 = 10;
    public static int radarEnemyRadiusRadarType5 = 10;
    
    //RadarPlayer
    public static float radarPlayerRadiusRadarType1 = 10f;
    public static float radarPlayerRadiusRadarType2 = 10.5f;
    public static float radarPlayerRadiusRadarType3 = 11f;
    public static float radarPlayerRadiusRadarType4 = 11.5f;
    public static float radarPlayerRadiusRadarType5 = 12f;

    //PercentagesPlayer
    public static float percentageAssiertFirinLaserPlayer = 0.5f;
    public static float percengateProtecionShieldPlayer = 0.5f;

    //percentagesEnemy
    public static float percentageAssiertFirinLaserEnemy = 0.5f;
    public static float percengateProtecionShieldEnemy= 0.5f;

    //spawmer poblation
    public static Vector3 positionSpawmerPosition = new Vector3(0, 0, 0);

    //Splash
    public static int timeAwaitSplash = 5000;

}
