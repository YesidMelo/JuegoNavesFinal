using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpawmerMaterialUIViewModelDelegate { }

public interface SpawmerMaterialUIViewModel {
    SpawmerMaterialUIViewModelDelegate myDelegate { get; set; }
    bool isAllMaterialsInLevel();
    bool isCreateMaterial();
    void setIsCreateMaterial(bool isCreateMaterial);

    void setCurrentMaterialSpawmer(GameObject materialSpawmer);
    void deleteSpawmerMaterial();
}

public class SpawmerMaterialUIViewModelImpl : SpawmerMaterialUIViewModel
{
    //uses cases
    private MaterialSpawmerSetCurrentMaterialGeneratorUseCase setCurrentMaterialGeneratorUseCase = new MaterialSpawmerSetCurrentMaterialGeneratorUseCaseImpl();
    private MaterialSpawmerIsAllMaterials1InLevelUseCase isAllMaterialsInLevelUseCase = new MaterialSpawmerIsAllMaterialsInLevelUseCaseImpl();

    //variables
    private SpawmerMaterialUIViewModelDelegate _myDelegate;
    private bool _isCreateMaterial = false;

    //public methods

    public SpawmerMaterialUIViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public void deleteSpawmerMaterial() => setCurrentMaterialGeneratorUseCase.invoke(materialSpawmer: null);

    public bool isAllMaterialsInLevel() => isAllMaterialsInLevelUseCase.invoke();

    public bool isCreateMaterial() => _isCreateMaterial;

    public void setCurrentMaterialSpawmer(GameObject materialSpawmer) => setCurrentMaterialGeneratorUseCase.invoke(materialSpawmer: materialSpawmer);

    public void setIsCreateMaterial(bool isCreateMaterial)
    {
        _isCreateMaterial = isCreateMaterial;
    }
}
