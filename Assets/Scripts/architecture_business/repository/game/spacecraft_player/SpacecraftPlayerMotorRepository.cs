using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerMotorRepository {
    public float speedMotor { get; }
    public List<MotorPlayer> listMotors { get; }
    public MotorModel currentMotorModel { get; }
    public bool loadMotors();
    public void setCurrentMotorModel(MotorModel motorModel);
    public void setListMotors(List<MotorPlayer> motorPlayers);
    public void clearCache();
}

public class SpacecraftPlayerMotorRepositoryImpl : SpacecraftPlayerMotorRepository
{
    private SpacecraftPlayerMotorCache cache = SpacecraftPlayerMotorCacheImpl.getInstance();

    public float speedMotor => cache.speedMotor;
    public List<MotorPlayer> listMotors => cache.listMotors;
    public MotorModel currentMotorModel => cache.currentMotorModel;
    public void clearCache() => cache.clearCache();
    public bool loadMotors() => cache.loadMotors();
    public void setCurrentMotorModel(MotorModel motorModel) => cache.setCurrentMotorModel(motorModel: motorModel);
    public void setListMotors(List<MotorPlayer> motorPlayers) => cache.setListMotors(motorPlayers);
}