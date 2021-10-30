using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCurrentRadiusRadarUseCase {
    int invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyCurrentRadiusRadarUseCaseImpl : SpacecraftEnemyCurrentRadiusRadarUseCase
{
    private SpacecraftEnemyRadarRepository repo = new SpacecraftEnemyRadarRepositoryImpl();

    public int invoke(IdentificatorModel identificator) => repo.radiusRadar(identificator);
}
