using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCurrentMotorUseCase {
    MotorEnemy invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyCurrentMotorUseCaseImpl : SpacecraftEnemyCurrentMotorUseCase
{
    private SpacecraftEnemyMotorRepository repo = new SpacecraftEnemyMotorRepositoryImpl();

    public MotorEnemy invoke(IdentificatorModel identificator) => repo.currentMotor(identificator);
}