using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerGetStringMaterialsUseCase {
    List<string> invoke();
}

public class MaterialSpawmerGetStringMaterialsUseCaseImpl : MaterialSpawmerGetStringMaterialsUseCase
{
    private LevelRepository levelRepository = new LevelRepositoryImpl();
    private MaterialSpawmerRepository materialSpawmerRepository = new MaterialSpawmerRepositoryImpl();

    public List<string> invoke()
        => materialSpawmerRepository.getListNumberMaterialsByLevel(level: levelRepository.getCurrentLevel);
}