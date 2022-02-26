using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerSetCurrentMaterialGeneratorUseCase {
    void invoke(GameObject materialSpawmer);
}

public class MaterialSpawmerSetCurrentMaterialGeneratorUseCaseImpl : MaterialSpawmerSetCurrentMaterialGeneratorUseCase
{
    private MaterialSpawmerRepository materialSpawmerRepository = new MaterialSpawmerRepositoryImpl();
    public void invoke(GameObject materialSpawmer) => materialSpawmerRepository.setCurrentMaterialSpawmer(materialSpawmer: materialSpawmer);
}