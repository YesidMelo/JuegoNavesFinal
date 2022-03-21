using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerBringMissingMaterials1UseCase {
    Dictionary<Material, int> invoke();
}

public class MaterialSpawmerBringMissingMaterials1UseCaseImpl : MaterialSpawmerBringMissingMaterials1UseCase
{
    private readonly MaterialSpawmerRepository materialSpawmerRepository = new MaterialSpawmerRepositoryImpl();
    private readonly LevelRepository levelRepository = new LevelRepositoryImpl();
    public Dictionary<Material, int> invoke() => materialSpawmerRepository.bringMissingMaterial(level: levelRepository.getCurrentLevel);
}