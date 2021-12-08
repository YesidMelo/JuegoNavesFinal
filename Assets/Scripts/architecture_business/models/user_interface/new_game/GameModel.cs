using System;
using System.Collections.Generic;

public class GameModel {

    public string namePlayer;
    public DateTime date;

    //laser
    public List<LaserPlayer> listLasers;

    //life
    public float life;
    public float maxLife;

    //motors
    public List<MotorPlayer> listMotors;

    //Radar
    public RadarPlayer currentRadarPlayer;

    //shield
    public ShieldPlayer currentShield;

    //storage
    public StoragePlayer currentStorage;

    //Structure
    public StructurePlayer currentStructure;
}