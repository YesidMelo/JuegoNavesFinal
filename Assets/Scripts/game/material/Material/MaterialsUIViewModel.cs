using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialsUIViewModelDelegate { }

public interface MaterialsUIViewModel {

    MaterialsUIViewModelDelegate myDelegate { set; }

    Material currentMaterial { get; }
    void destroyMaterial(GameObject currentMaterial);
    void addMaterialToSpawmer(GameObject currentMaterial);
}

public class MaterialUIViewModelImpl: MaterialsUIViewModel {

    //uses cases
    private MaterialGetRandomMaterialUseCase getRandomMaterialUseCase = new MaterialGetRandomMaterialUseCaseImpl();
    private MaterialSpawmerAddMaterialUseCase addMaterialUseCase = new MaterialSpawmerAddMaterialUseCaseImpl();
    private MaterialSpawmerRemoveMaterialUseCase removeMaterialUseCase = new MaterialSpawmerRemoveMaterialUseCaseImpl();

    //variables
    private MaterialsUIViewModelDelegate _myDelegate;
    private Material _currentMaterial;

    public MaterialUIViewModelImpl() {
        _currentMaterial = getRandomMaterialUseCase.invoke();
    }

    //public methods
    public MaterialsUIViewModelDelegate myDelegate { 
        set => _myDelegate = value;
    }

    public Material currentMaterial { 
        get => _currentMaterial; 
    }

    public void addMaterialToSpawmer(GameObject currentMaterial) => addMaterialUseCase.invoke(
        material: _currentMaterial,
        currentMaterial: currentMaterial
    );

    public void destroyMaterial(GameObject currentMaterial)
    {
        removeMaterialUseCase.invoke(currentMaterial: currentMaterial, material: _currentMaterial);
    }


    //private methods
}
