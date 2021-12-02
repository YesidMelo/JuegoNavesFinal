using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetCurrentStorageUseCase {
    StoragePlayer invoke();
}

public class SpacecraftPlayerGetCurrentStorageUseCaseImpl : SpacecraftPlayerGetCurrentStorageUseCase
{
    private SpacecraftPlayerStorageRepository repo = new SpacecraftPlayerStorageRepositoryImpl();
    public StoragePlayer invoke() => repo.currentStorage;
}