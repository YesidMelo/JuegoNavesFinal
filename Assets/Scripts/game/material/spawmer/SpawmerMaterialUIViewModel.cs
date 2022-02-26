using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpawmerMaterialUIViewModelDelegate { }

public interface SpawmerMaterialUIViewModel {
    SpawmerMaterialUIViewModelDelegate myDelegate { get; set; }
    void setCurrentMaterialSpawmer(GameObject materialSpawmer);
    void deleteSpawmerMaterial();
}

public class SpawmerMaterialUIViewModelImpl : SpawmerMaterialUIViewModel
{
    //uses cases
    private MaterialSpawmerSetCurrentMaterialGeneratorUseCase setCurrentMaterialGeneratorUseCase = new MaterialSpawmerSetCurrentMaterialGeneratorUseCaseImpl();

    //variables
    private SpawmerMaterialUIViewModelDelegate _myDelegate;

    //public methods

    public SpawmerMaterialUIViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public void deleteSpawmerMaterial() => setCurrentMaterialGeneratorUseCase.invoke(materialSpawmer: null);

    public void setCurrentMaterialSpawmer(GameObject materialSpawmer) => setCurrentMaterialGeneratorUseCase.invoke(materialSpawmer: materialSpawmer);
}
