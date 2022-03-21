using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialsUIViewModelDelegate { }

public interface MaterialsUIViewModel {

    MaterialsUIViewModelDelegate myDelegate { set; }

    Material currentMaterial { get; }
    void destroyMaterial(GameObject currentMaterial);
    void addMaterialToSpawmer(Material material);
}

public class MaterialUIViewModelImpl: MaterialsUIViewModel {

    //uses cases
    private readonly MaterialSpawmerRemoveMaterialUseCase removeMaterialUseCase = new MaterialSpawmerRemoveMaterialUseCaseImpl();

    //variables
    private MaterialsUIViewModelDelegate _myDelegate;
    private Material _currentMaterial;


    //public methods
    public MaterialsUIViewModelDelegate myDelegate { 
        set => _myDelegate = value;
    }

    public Material currentMaterial { 
        get => _currentMaterial; 
    }

    public void addMaterialToSpawmer(Material material) {
        _currentMaterial = material;
    }

    public void destroyMaterial(GameObject currentMaterial)
    {
        removeMaterialUseCase.invoke(currentMaterial: currentMaterial, material: _currentMaterial);
    }

    //private methods
}
