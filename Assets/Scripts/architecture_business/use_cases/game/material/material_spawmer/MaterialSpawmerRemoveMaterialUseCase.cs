using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerRemoveMaterialUseCase {
    void invoke(GameObject currentMaterial, Material material);
}

public class MaterialSpawmerRemoveMaterialUseCaseImpl : MaterialSpawmerRemoveMaterialUseCase
{
    private readonly MaterialSpawmerRepository materialSpawmerRepository = new MaterialSpawmerRepositoryImpl();
    private readonly LevelRepository levelRepository = new LevelRepositoryImpl();

    public void invoke(GameObject currentMaterial, Material material)
    {
        materialSpawmerRepository.removeMaterial(
            gameObject: currentMaterial,
            level: levelRepository.getCurrentLevel,
            material: material
        );
    }
}