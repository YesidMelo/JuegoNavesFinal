using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetSpeedMotorUseCase {
    float invoke();
}

public class SpacecraftPlayerGetSpeedMotorUseCaseImpl : SpacecraftPlayerGetSpeedMotorUseCase
{
    private SpacecraftPlayerMotorRepository repo = new SpacecraftPlayerMotorRepositoryImpl();
    public float invoke() => repo.speedMotor;
}