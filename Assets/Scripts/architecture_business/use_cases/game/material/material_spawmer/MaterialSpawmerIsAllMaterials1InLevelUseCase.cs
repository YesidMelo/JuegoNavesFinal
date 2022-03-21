using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerIsAllMaterials1InLevelUseCase {
    bool invoke();
}

public class MaterialSpawmerIsAllMaterialsInLevelUseCaseImpl : MaterialSpawmerIsAllMaterials1InLevelUseCase
{
    private readonly MaterialSpawmerRepository materialSpawmerRepository = new MaterialSpawmerRepositoryImpl();
    private readonly LevelRepository levelRepository = new LevelRepositoryImpl();

    public bool invoke() => materialSpawmerRepository.isAllMaterialsInLevel(level: levelRepository.getCurrentLevel);

}