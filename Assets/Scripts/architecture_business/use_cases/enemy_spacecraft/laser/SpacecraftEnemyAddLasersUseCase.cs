using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyAddLasersUseCase {
    void invoke(List<LaserEnemy> lasers, IdentificatorModel identificatorModel);
}

public class SpacecraftEnemyAddLasersUseCaseImpl : SpacecraftEnemyAddLasersUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();

    public void invoke(List<LaserEnemy> lasers, IdentificatorModel identificatorModel) => repo.setListLasers(lasers, identificatorModel);
}