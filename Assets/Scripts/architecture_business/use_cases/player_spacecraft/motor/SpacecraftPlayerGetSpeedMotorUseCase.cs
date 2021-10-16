using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetSpeedMotorUseCase {
    int invoke();
}

public class SpacecraftPlayerGetSpeedMotorUseCaseImpl : SpacecraftPlayerGetSpeedMotorUseCase
{
    private SpacecraftPlayerMotorRepository repo = new SpacecraftPlayerMotorRepositoryImpl();
    public int invoke() => repo.speedMotor;
}