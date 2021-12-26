using System;
using System.Collections.Generic;

public class GameModel {

    public long? id;
    public string? namePlayer;
    public DateTime? date;

    public LaserModel laserModel;
    public LifeModel lifeModel;
    public MotorModel motorModel;
    public RadarModel radarModel;
    public ShieldModel shieldModel;
    public StorageModel storageModel;
    public StructureModel structureModel;
}