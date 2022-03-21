using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmerMaterialsCounter : MonoBehaviour, SpawmerMaterialsCounterViewModelDelegate
{
    public List<string> listMaterials = new List<string>();

    //private variables
    private SpawmerMaterialsCounterViewModel _viewModel = new SpawmerMaterialsCounterViewModelImpl();
    private DateTime nextUpdate;


    //LifeCycle
    void Start()
    {
        _viewModel.myDelegate = this;
    }

    
    void Update()
    {
        updateUI();
    }

    //ui methods
    private void updateUI()
    {
        updateListUI();
    }

    private void updateListUI()
    {
        if (nextUpdate > DateTime.Now) return;

        nextUpdate = DateTime.Now.AddMilliseconds(Constants.timeMaterialSpawmGeneration);
        listMaterials = _viewModel.stringMaterials;
    }

    //pulic methods
    //private methods


    //delegate methods
}
