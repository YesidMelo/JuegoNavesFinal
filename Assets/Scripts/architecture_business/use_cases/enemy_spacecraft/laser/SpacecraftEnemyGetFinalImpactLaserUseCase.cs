using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetFinalImpactLaserUseCase {
    Laser invoke(IdentificatorModel identificatorModel);
}
public class SpacecraftEnemyGetFinalImpactLaserUseCaseImpl : SpacecraftEnemyGetFinalImpactLaserUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();

    public Laser invoke(IdentificatorModel identificatorModel) => repo.finalImpactLaser(identificatorModel);
}