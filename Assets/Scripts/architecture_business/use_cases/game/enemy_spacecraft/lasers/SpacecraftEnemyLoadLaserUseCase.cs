using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLoadLaserUseCase {
    bool invoke(IdentificatorModel identificatorModel);
}

public class SpacecraftEnemyLoadLaserUseCaseImpl : SpacecraftEnemyLoadLaserUseCase
{
    private SpacecraftEnemyLaserRepository repoLaser = new SpacecraftEnemyLaserRepositoryImpl();
    private SpacecraftEnemyRepository repoSpacecraft = new SpacecraftEnemyRepositoryImpl();

    public bool invoke(IdentificatorModel identificatorModel) => repoLaser.loadSpacecraft(identificatorModel, repoSpacecraft.currentSpacecraft(identificatorModel));
}