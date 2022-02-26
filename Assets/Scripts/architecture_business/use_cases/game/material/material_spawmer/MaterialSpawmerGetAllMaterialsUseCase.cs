using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialSpawmerGetAllMaterialsUseCase {
    List<GameObject> invoke();
}

public class MaterialSpawmerGetAllMaterialsUseCaseImpl : MaterialSpawmerGetAllMaterialsUseCase
{
    private MaterialSpawmerRepository materialSpawmerRepository = new MaterialSpawmerRepositoryImpl();

    public List<GameObject> invoke() => materialSpawmerRepository.getAllListMaterial();
}