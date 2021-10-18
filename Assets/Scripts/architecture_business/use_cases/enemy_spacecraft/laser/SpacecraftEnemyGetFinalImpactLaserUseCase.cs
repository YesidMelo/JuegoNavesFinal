using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetFinalImpactLaserUseCase {
    LaserEnemy invoke(IdentificatorModel identificatorModel);
}
public class SpacecraftEnemyGetFinalImpactLaserUseCaseImpl : SpacecraftEnemyGetFinalImpactLaserUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();

    public LaserEnemy invoke(IdentificatorModel identificatorModel) => repo.finalImpactLaser(identificatorModel);
}