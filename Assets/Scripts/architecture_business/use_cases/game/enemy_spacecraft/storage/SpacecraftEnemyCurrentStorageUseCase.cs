using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCurrentStorageUseCase {
    StorageEnemy invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyCurrentStorageUseCaseImpl : SpacecraftEnemyCurrentStorageUseCase
{
    private SpacecraftEnemyStorageRepository repo = new SpacecraftEnemyStorageRepositoryImpl();

    public StorageEnemy invoke(IdentificatorModel identificator) => repo.currentStorage(identificator);
}