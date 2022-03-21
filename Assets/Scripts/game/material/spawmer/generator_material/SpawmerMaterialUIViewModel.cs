using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpawmerMaterialUIViewModelDelegate {
    void isAllMaterials(bool isAllMaterials);
    void deleteMaterials(List<GameObject> materials);
}

public interface SpawmerMaterialUIViewModel {
    SpawmerMaterialUIViewModelDelegate myDelegate { get; set; }
    void checkIsAllMaterials();
    void deleteCurrentSpawmer();

}

public class SpawmerMaterialUIViewModelImpl : SpawmerMaterialUIViewModel
{
    //uses cases
    private readonly MaterialSpawmerIsAllMaterials1InLevelUseCase isAllMaterials1InLevelUseCase = new MaterialSpawmerIsAllMaterialsInLevelUseCaseImpl();
    private readonly MaterialSpawmerSetCurrentMaterialGeneratorUseCase setCurrentMaterialGeneratorUseCase = new MaterialSpawmerSetCurrentMaterialGeneratorUseCaseImpl();

    //private variables
    private SpawmerMaterialUIViewModelDelegate _delegate;

    //public variables

    //public methods

    public SpawmerMaterialUIViewModelDelegate myDelegate { 
        get => _delegate; 
        set => _delegate = value; 
    }

    public void checkIsAllMaterials() => _delegate.isAllMaterials(isAllMaterials: isAllMaterials1InLevelUseCase.invoke());

    public void deleteCurrentSpawmer() => setCurrentMaterialGeneratorUseCase.invoke(materialSpawmer: null);

    //private methods

}
