using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyDeleteLasersUseCase {
    void invoke(IdentificatorModel identificatorModel);
}
public class SpacecraftEnemyDeleteLasersUseCaseImpl : SpacecraftEnemyDeleteLasersUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();

    public void invoke(IdentificatorModel identificatorModel) => repo.deleteLaser(identificatorModel);
}