using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLoadStorageUseCase {
    bool invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyLoadStorageUseCaseImpl : SpacecraftEnemyLoadStorageUseCase
{
    private SpacecraftEnemyRepository repoSpacecraft = new SpacecraftEnemyRepositoryImpl();
    private SpacecraftEnemyStorageRepository repoStorage = new SpacecraftEnemyStorageRepositoryImpl();

    public bool invoke(IdentificatorModel identificator) => repoStorage.loadStorage(identificator, repoSpacecraft.currentSpacecraft(identificator));
}