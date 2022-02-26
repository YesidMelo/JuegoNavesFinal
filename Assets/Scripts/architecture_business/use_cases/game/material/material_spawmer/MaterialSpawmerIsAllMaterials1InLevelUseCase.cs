using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerIsAllMaterials1InLevelUseCase {
    bool invoke();
}

public class MaterialSpawmerIsAllMaterialsInLevelUseCaseImpl : MaterialSpawmerIsAllMaterials1InLevelUseCase
{
    private MaterialSpawmerRepository materialSpawmerRepository = new MaterialSpawmerRepositoryImpl();

    public bool invoke() => materialSpawmerRepository.isAllMaterialsInLevel();

}