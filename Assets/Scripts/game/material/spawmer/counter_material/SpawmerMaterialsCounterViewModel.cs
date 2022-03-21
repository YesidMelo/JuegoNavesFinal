using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpawmerMaterialsCounterViewModelDelegate { }

public interface SpawmerMaterialsCounterViewModel {
    SpawmerMaterialsCounterViewModelDelegate myDelegate { set; get; }
    List<string> stringMaterials { get; }
}

public class SpawmerMaterialsCounterViewModelImpl : SpawmerMaterialsCounterViewModel
{
    //uses cases
    private MaterialSpawmerGetStringMaterialsUseCase getStringMaterialsUseCase = new MaterialSpawmerGetStringMaterialsUseCaseImpl();

    //variables
    private SpawmerMaterialsCounterViewModelDelegate _myDelegate;

    //public methods
    public SpawmerMaterialsCounterViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public List<string> stringMaterials => getStringMaterialsUseCase.invoke();
}