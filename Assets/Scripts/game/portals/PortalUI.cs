using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalUI : MonoBehaviour, PortalUIViewModelDelegate
{
    
    public Level currentLevel = Level.LEVEL1_SECTION1;
    public Level levelToChange = Level.LEVEL1_SECTION1;

    private PortalUIViewModel _viewModel = new PortalUIViewModelImpl();

    void Start()
    {
        _viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = _viewModel.getCurrentLevel;
        updateLevelInUnity();
    }

    //public methods

    //private methods

    //ui unity methods
    private void updateLevelInUnity() {
        if (levelToChange == currentLevel) return;
        _viewModel.changeLevel(level: levelToChange);
    }
}
