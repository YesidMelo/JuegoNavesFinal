using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerGetCurrentMaterialGeneratorUseCase {
    GameObject invoke();
}

public class MaterialSpawmerGetCurrentMaterialGeneratorUseCaseImpl : MaterialSpawmerGetCurrentMaterialGeneratorUseCase
{
    private MaterialSpawmerRepository materialSpawmerRepository = new MaterialSpawmerRepositoryImpl();
    public GameObject invoke() => materialSpawmerRepository.getCurrentMaterialSpawmer();
}