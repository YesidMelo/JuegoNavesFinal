using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetTypeLaserUseCase {
    LaserEnemy invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyGetTypeLaserUseCaseImpl : SpacecraftEnemyGetTypeLaserUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();

    public LaserEnemy invoke(IdentificatorModel identificator) => repo.typeLaser(identificator);
}