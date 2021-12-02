using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCurrentSpeedUseCase {
    float invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyCurrentSpeedUseCaseImpl : SpacecraftEnemyCurrentSpeedUseCase
{
    private SpacecraftEnemyMotorRepository repo = new SpacecraftEnemyMotorRepositoryImpl();
    public float invoke(IdentificatorModel identificator) => repo.currentSpeed(identificator);
}