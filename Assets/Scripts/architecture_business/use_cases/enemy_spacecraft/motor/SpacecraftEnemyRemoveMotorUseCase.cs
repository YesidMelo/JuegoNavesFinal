using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRemoveMotorUseCase {
    void invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyRemoveMotorUseCaseImpl : SpacecraftEnemyRemoveMotorUseCase
{
    private SpacecraftEnemyMotorRepository repo = new SpacecraftEnemyMotorRepositoryImpl();

    public void invoke(IdentificatorModel identificator) => repo.removeMotor(identificator);
}