using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerAddMaterialUseCase {
    void invoke(GameObject currentMaterial, Material material);
}
public class MaterialSpawmerAddMaterialUseCaseImpl : MaterialSpawmerAddMaterialUseCase
{
    private MaterialSpawmerRepository materialSpawmerRepository = new MaterialSpawmerRepositoryImpl();
    private LevelRepository levelRepository = new LevelRepositoryImpl();
    public void invoke(GameObject currentMaterial, Material material) {
        materialSpawmerRepository.addMaterial(
            materialObject: currentMaterial, 
            material: material,
            level: levelRepository.getCurrentLevel
        );
    }
}