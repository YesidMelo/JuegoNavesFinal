using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialGetRandomMaterialUseCase {
    Material invoke();
}

public class MaterialGetRandomMaterialUseCaseImpl : MaterialGetRandomMaterialUseCase
{

    private readonly MaterialRepository materialRepository = new MaterialRepositoryImpl();
    private readonly LevelRepository levelRepository = new LevelRepositoryImpl();

    public Material invoke() => materialRepository.getRandomMaterial(level: levelRepository.getCurrentLevel);
}