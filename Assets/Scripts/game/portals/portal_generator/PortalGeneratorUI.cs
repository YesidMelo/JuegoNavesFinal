using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGeneratorUI : MonoBehaviour, PortalGeneratorViewModelDelegate
{
    public Level currentLevel;
    public GameObject prefabPortal;
    private PortalGeneratorViewModel _viewModel = new PortalGeneratorViewModelImpl();

    void Start()
    {
        _viewModel.myDelegate = this;
        _viewModel.loadPortals();
    }

    
    void Update()
    {
        checkCurrentLevel();
    }

    //private methods
    private void checkCurrentLevel() {
        if (currentLevel == _viewModel.getCurrentLevel) return;
        currentLevel = _viewModel.getCurrentLevel;
        _viewModel.loadPortals();
    }

    //delegates
    public void generatePortals(List<PortalModel> portalModels)
    {
        foreach (PortalModel currentPortal in portalModels) {
            GameObject portal = Instantiate(prefabPortal);

            if (portal == null) continue;
            portal.transform.position = new Vector3(currentPortal.positionX, currentPortal.positionY, 0f);
            portal.name = Constants.namePortal.addRandomString(length: 4);
            _viewModel.addPortal(portal: portal);

            PortalUI portalUI = portal.GetComponent<PortalUI>();
            if (portalUI == null) continue;
            portalUI.currentPortal = currentPortal;
        }
    }

    public void deleteAllPortals(List<GameObject> allPortals)
    {
        try
        {
            GameObject[] listToDelete = allPortals.ToArray();

            foreach (GameObject currentPortal in listToDelete)
            {
                Destroy(currentPortal);
                _viewModel.deletePortal(portal: currentPortal);
            }
        } catch (Exception e) {
            Debug.Log(e.Message);
        }

    }
}
