using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerUpdateListMotorsUseCase {
    void invoke(List<MotorPlayer> listMotors);
}
public class SpacecraftPlayerUpdateListMotorsUseCaseImpl : SpacecraftPlayerUpdateListMotorsUseCase
{
    private SpacecraftPlayerMotorRepository repo = new SpacecraftPlayerMotorRepositoryImpl();
    public void invoke(List<MotorPlayer> listMotors) => repo.setListMotors(listMotors);
}