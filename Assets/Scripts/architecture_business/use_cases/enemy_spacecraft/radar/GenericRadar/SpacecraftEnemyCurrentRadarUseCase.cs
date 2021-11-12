using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCurrentRadarUseCase {
    RadarEnemy invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyCurrentRadarUseCaseImpl : SpacecraftEnemyCurrentRadarUseCase
{
    private SpacecraftEnemyRadarRepository repo = new SpacecraftEnemyRadarRepositoryImpl();

    public RadarEnemy invoke(IdentificatorModel identificator) => repo.currentRada(identificator);
}