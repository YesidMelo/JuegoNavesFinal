using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGeneratorUI : MonoBehaviour, PortalGeneratorViewModelDelegate
{
    public Level currentLevel;
    private PortalGeneratorViewModel _viewModel = new PortalGeneratorViewModelImpl();


    void Start()
    {
        _viewModel.myDelegate = this;
    }

    
    void Update()
    {
        checkCurrentLevel();
    }

    //private methods
    private void checkCurrentLevel() {
        if (currentLevel == _viewModel.getCurrentLevel) return;
        currentLevel = _viewModel.getCurrentLevel;
        Debug.Log("cambio el nivel");
    }

    //delegates
    public void generatePortals(List<PortalModel> portalModels)
    {
        Debug.Log($"portales");
    }
}
