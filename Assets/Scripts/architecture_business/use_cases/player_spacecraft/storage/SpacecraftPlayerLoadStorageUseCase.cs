using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLoadStorageUseCase {
    bool invoke();
}

public class SpacecraftPlayerLoadStorageUseCaseImpl : SpacecraftPlayerLoadStorageUseCase
{
    private SpacecraftPlayerStorageRepository repo = new SpacecraftPlayerStorageRepositoryImpl();
    public bool invoke() => repo.loadStorage();
}