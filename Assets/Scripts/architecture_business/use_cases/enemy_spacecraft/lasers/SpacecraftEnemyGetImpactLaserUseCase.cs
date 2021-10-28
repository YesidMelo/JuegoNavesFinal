using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetImpactLaserUseCase {
    int invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyGetImpactLaserUseCaseImpl : SpacecraftEnemyGetImpactLaserUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();
    public int invoke(IdentificatorModel identificator) => repo.impactLaser(identificator);
}