using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportPlayerUI : MonoBehaviour, LifeSupportPlayerUIViewModelDelegate
{
    public LifeSupportPlayer currentLifeSupport;

    private LifeSupportPlayerUIViewModel _viewModel = new LifeSupportPlayerUIViewModelImpl();

    // Start is called before the first frame update
    void Start()
    {
        _viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        checkCurrentTypeLifeSupport();
    }

    //private methods
    private void checkCurrentTypeLifeSupport() {
        if (_viewModel == null) return;
        currentLifeSupport = _viewModel.getCurrentLifeSupport;
    }
}
