using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetListMotorUseCase {
    List<MotorPlayer> invoke();
}
public class SpacecraftPlayerGetListMotorUseCaseImpl : SpacecraftPlayerGetListMotorUseCase
{
    private SpacecraftPlayerMotorRepository repo = new SpacecraftPlayerMotorRepositoryImpl();

    public List<MotorPlayer> invoke() => repo.listMotors;
}
