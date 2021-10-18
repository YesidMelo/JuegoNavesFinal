using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLoadLasersUseCase {
    bool invoke(IdentificatorModel identificatorModel);
}

public class SpacecraftEnemyLoadLasersUseCaseImpl : SpacecraftEnemyLoadLasersUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();
    public bool invoke(IdentificatorModel identificatorModel) => repo.loadListLasers(identificatorModel);
}