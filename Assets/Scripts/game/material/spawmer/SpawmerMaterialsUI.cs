using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpawmerMaterialsUIDelegate { 

}

public class SpawmerMaterialsUI : MonoBehaviour, SpawmerMaterialUIViewModelDelegate
{
    public GameModel prefabMaterial;

    //variables
    public SpawmerMaterialsUIDelegate myDelegate;

    private SpawmerMaterialUIViewModel _viewModel = new SpawmerMaterialUIViewModelImpl();
    
    //lifeCycle

    void Start()
    {
        _viewModel.myDelegate = this;
        _viewModel.setCurrentMaterialSpawmer(gameObject);
    }

    private void OnDestroy()
    {
        _viewModel.deleteSpawmerMaterial();
    }

    //public methods

    //private methods
}
