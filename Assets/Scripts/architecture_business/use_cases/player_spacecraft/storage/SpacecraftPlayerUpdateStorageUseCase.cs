using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerUpdateStorageUseCase {
    void invoke(StoragePlayer storage);
}
public class SpacecraftPlayerUpdateStorageUseCaseImpl : SpacecraftPlayerUpdateStorageUseCase
{
    private SpacecraftPlayerStorageRepository repo = new SpacecraftPlayerStorageRepositoryImpl();
    public void invoke(StoragePlayer storage) => repo.updateStorage(storage);
}