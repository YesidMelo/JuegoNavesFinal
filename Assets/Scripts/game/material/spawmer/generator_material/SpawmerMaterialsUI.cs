using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public interface SpawmerMaterialsUIDelegate { 

}

public class SpawmerMaterialsUI : MonoBehaviour, SpawmerMaterialUIViewModelDelegate
{
    public GameObject prefabMaterial;
    public bool isAllMaterialsInLevel;

    //private SynchronizationContext syncContext;
    private DateTime nextUpdate;

    //variables
    public SpawmerMaterialsUIDelegate myDelegate;

    private SpawmerMaterialUIViewModel _viewModel = new SpawmerMaterialUIViewModelImpl();
    
    //lifeCycle

    void Start()
    {
        _viewModel.myDelegate = this; 
    }

    private void Update()
    {
        updateValues();

    }

    private void OnDestroy()
    {
        _viewModel.deleteCurrentSpawmer();
    }

    //ui methods
    private void updateValues()
    {
        if (nextUpdate > DateTime.Now) return;
        nextUpdate = DateTime.Now.AddMilliseconds(Constants.timeMaterialSpawmGeneration);
        _viewModel.checkIsAllMaterials();
        generateMaterials();
    }

    //public methods

    //private methods
    private void generateMaterials()
    {
        if (isAllMaterialsInLevel) return;
        GameObject materialInstance = Instantiate(prefabMaterial);
        
    }

    //delegates
    public void isAllMaterials(bool isAllMaterials) {
        isAllMaterialsInLevel = isAllMaterials;
    }

    public void deleteMaterials(List<GameObject> materials)
    {
        foreach (GameObject currentMaterial in materials)
        {
            Destroy(currentMaterial);
        }
    }
}
    