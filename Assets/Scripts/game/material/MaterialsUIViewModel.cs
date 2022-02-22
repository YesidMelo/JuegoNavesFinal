using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MaterialsUIViewModelDelegate { }

public interface MaterialsUIViewModel {

    MaterialsUIViewModelDelegate myDelegate { set; }

    Material currentMaterial { get; }
    void selectMaterialRandom();

}

public class MaterialUIViewModelImpl: MaterialsUIViewModel {

    //uses cases

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

    public void selectMaterialRandom()
    {
        if (_currentMaterial != Material.NONE) return;
        _currentMaterial = Material.MATERIAL_1.getRandomMaterial();
        Debug.Log("MAterial actual");
    }

    //private methods
}
