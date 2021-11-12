using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLoadRadarUseCase {
    bool invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyLoadRadarUseCaseImpl : SpacecraftEnemyLoadRadarUseCase
{
    private SpacecraftEnemyRadarRepository repoRadar = new SpacecraftEnemyRadarRepositoryImpl();
    private SpacecraftEnemyRepository repoSpacecraft = new SpacecraftEnemyRepositoryImpl();

    public bool invoke(IdentificatorModel identificator) => repoRadar.loadRadar(identificator, repoSpacecraft.currentSpacecraft(identificator));
}