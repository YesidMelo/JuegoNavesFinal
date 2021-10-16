using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLoadMotorUseCase {
    bool invoke();
}

public class SpacecraftPlayerLoadMotorUseCaseImpl : SpacecraftPlayerLoadMotorUseCase
{
    private SpacecraftPlayerMotorRepository repo = new SpacecraftPlayerMotorRepositoryImpl();
    public bool invoke() => repo.loadMotors();
}