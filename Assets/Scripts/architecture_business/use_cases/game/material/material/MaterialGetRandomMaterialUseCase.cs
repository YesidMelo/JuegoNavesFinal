using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialGetRandomMaterialUseCase {
    Material invoke();
}

public class MaterialGetRandomMaterialUseCaseImpl : MaterialGetRandomMaterialUseCase
{

    private MaterialRepository materialRepository = new MaterialRepositoryImpl();

    public Material invoke() => materialRepository.getRandomMaterial();
}