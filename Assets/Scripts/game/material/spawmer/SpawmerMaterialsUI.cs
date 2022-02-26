using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpawmerMaterialsUIDelegate { 

}

public class SpawmerMaterialsUI : MonoBehaviour, SpawmerMaterialUIViewModelDelegate
{
    public GameObject prefabMaterial;
    public int numberMaterials;

    //variables
    public SpawmerMaterialsUIDelegate myDelegate;

    private SpawmerMaterialUIViewModel _viewModel = new SpawmerMaterialUIViewModelImpl();
    
    //lifeCycle

    void Start()
    {
        _viewModel.myDelegate = this;
        _viewModel.setCurrentMaterialSpawmer(gameObject);
    }

    private void Update()
    {
        if (_viewModel.isAllMaterialsInLevel()) return;
        if (_viewModel.isCreateMaterial()) return;
        createMaterial();
    }

    private void OnDestroy()
    {
        _viewModel.deleteSpawmerMaterial();
    }

    //public methods

    //private methods

    private void createMaterial() {
        _viewModel.setIsCreateMaterial(isCreateMaterial: true);
        GameObject instance = Instantiate(prefabMaterial);
        _viewModel.setIsCreateMaterial(isCreateMaterial: false);
    }
}
