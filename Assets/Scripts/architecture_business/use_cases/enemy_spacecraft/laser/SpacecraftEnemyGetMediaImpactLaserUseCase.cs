using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetMediaImpactLaserUseCase {
    int invoke(IdentificatorModel identificatorModel);
}
public class SpacecraftEnemyGetMediaImpactLaserUseCaseImpl : SpacecraftEnemyGetMediaImpactLaserUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();

    public int invoke(IdentificatorModel identificatorModel) => repo.mediaImpactLaser(identificatorModel);
}