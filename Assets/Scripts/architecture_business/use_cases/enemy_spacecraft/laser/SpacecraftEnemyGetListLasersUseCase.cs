using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetListLasersUseCase {
    List<LaserEnemy> invoke(IdentificatorModel identificatorModel);
}

public class SpacecraftEnemyGetListLasersUseCaseImpl : SpacecraftEnemyGetListLasersUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();

    public List<LaserEnemy> invoke(IdentificatorModel identificatorModel) => repo.listLasers(identificatorModel);
}
