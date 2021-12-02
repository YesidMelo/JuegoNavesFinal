using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRemoveStorageUseCase {
    void invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyRemoveStorageUseCaseImpl : SpacecraftEnemyRemoveStorageUseCase
{
    private SpacecraftEnemyStorageRepository repo = new SpacecraftEnemyStorageRepositoryImpl();
    public void invoke(IdentificatorModel identificator) => repo.removeStorage(identificator);
}