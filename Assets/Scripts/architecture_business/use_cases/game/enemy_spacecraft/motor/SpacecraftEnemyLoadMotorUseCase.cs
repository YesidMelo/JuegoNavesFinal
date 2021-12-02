using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLoadMotorUseCase {
    bool invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyLoadMotorUseCaseImpl : SpacecraftEnemyLoadMotorUseCase
{
    private SpacecraftEnemyMotorRepository repoMotor = new SpacecraftEnemyMotorRepositoryImpl();
    private SpacecraftEnemyRepository repoSpacecraft = new SpacecraftEnemyRepositoryImpl();

    public bool invoke(IdentificatorModel identificator) => repoMotor.loadMotor(identificator, repoSpacecraft.currentSpacecraft(identificator));
}