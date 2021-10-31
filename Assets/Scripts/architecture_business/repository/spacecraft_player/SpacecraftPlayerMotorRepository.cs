using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerMotorRepository {
    public float speedMotor { get; }
    public List<MotorPlayer> listMotors { get; }

    public bool loadMotors();
    public void setListMotors(List<MotorPlayer> motorPlayers);
}

public class SpacecraftPlayerMotorRepositoryImpl : SpacecraftPlayerMotorRepository
{
    private SpacecraftPlayerMotorCache cache = SpacecraftPlayerMotorCacheImpl.getInstance();

    public float speedMotor => cache.speedMotor;

    public List<MotorPlayer> listMotors => cache.listMotors;

    public bool loadMotors() => cache.loadMotors();

    public void setListMotors(List<MotorPlayer> motorPlayers) => cache.setListMotors(motorPlayers);
}