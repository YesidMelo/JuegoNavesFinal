using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerMotorCache
{
    public int speedMotor { get; }
    public List<MotorPlayer> listMotors{ get; }

    public bool loadMotors();
    public void setListMotors(List<MotorPlayer> motorPlayers);
}

public class SpacecraftPlayerMotorCacheImpl : SpacecraftPlayerMotorCache
{
    private static SpacecraftPlayerMotorCacheImpl instance;
    public static SpacecraftPlayerMotorCacheImpl getInstance() {
        if (instance == null) {
            instance = new SpacecraftPlayerMotorCacheImpl();
        }
        return instance;
    }

    private int _speedMotor = 1;
    private List<MotorPlayer> _listMotors = new List<MotorPlayer>();

    public int speedMotor => _speedMotor;

    public List<MotorPlayer> listMotors => _listMotors;

    public bool loadMotors()
    {
        if (listMotors.Count != 0) return true;
        _listMotors.Add(MotorPlayer.TYPE_1);
        return true;
    }

    public void setListMotors(List<MotorPlayer> motorPlayers)
    {
        if (motorPlayers.Count == 0) return;
        _listMotors = motorPlayers;
        calculateSpeedMotor();
    }

    //Private functions
    public void calculateSpeedMotor() {
        if (_listMotors.Count == 0) return;
        int finalSpeed = 0;

        foreach(MotorPlayer currentMotor in _listMotors) {
            finalSpeed = speedMotor + getSpeedMotor(currentMotor);
        }
        _speedMotor = finalSpeed;
    }

    int getSpeedMotor(MotorPlayer motor) {
        int speed = 1;
        switch (motor) {
            case MotorPlayer.TYPE_2:
                speed = Constants.speedMotorPlayerType2;
                break;
            case MotorPlayer.TYPE_3:
                speed = Constants.speedMotorPlayerType3;
                break;
            case MotorPlayer.TYPE_4:
                speed = Constants.speedMotorPlayerType4;
                break;
            case MotorPlayer.TYPE_5:
                speed = Constants.speedMotorPlayerType5;
                break;
            case MotorPlayer.TYPE_1:
            default:
                speed = Constants.speedMotorPlayerType1;
                break;
        }
        return speed;
    }

}
