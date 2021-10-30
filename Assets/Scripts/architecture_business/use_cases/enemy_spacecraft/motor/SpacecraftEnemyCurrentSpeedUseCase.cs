using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCurrentSpeedUseCase {
    int invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyCurrentSpeedUseCaseImpl : SpacecraftEnemyCurrentSpeedUseCase
{
    private SpacecraftEnemyMotorRepository repo = new SpacecraftEnemyMotorRepositoryImpl();
    public int invoke(IdentificatorModel identificator) => repo.currentSpeed(identificator);
}