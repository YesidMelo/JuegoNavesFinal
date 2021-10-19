using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLifePlayer : MonoBehaviour, HandlerLifePlayerViewModelDelegate
{
    public StructurePlayer currentStructure = StructurePlayer.TYPE_1;
    public bool loadLifeFromUI = false;
    public bool updateStructureLifeFromUI = false;
    public bool updateCurrentLife = false;
    public int maxLife = 0;
    public int currentLife = 0;

    private HandlerLifePlayerViewModel viewModel = new HandlerLifePlayerViewModelImpl();

    
    void Start()
    {
        viewModel.myDelegate = this;
        viewModel.loadLife();
    }

    // Update is called once per frame
    void Update()
    {
        loadLifeFromUIUnity();
        updateStructureLifeFromUIUnity();
        updateCurrentLifeFromUIUnity();
    }

    //public methods
    public void updateStructureLife(StructurePlayer structure) {
        if (viewModel == null) return;
        viewModel.setStructurePlayer(structure);
        
    }

    public void updateCurrentStructureLife(int currentLife) {
        if (viewModel == null) return;
        viewModel.updateCurrentLife(currentLife);
    }

    //private methods

    //ui unity methods
    private void loadLifeFromUIUnity() {
        if (!loadLifeFromUI) return;
        loadLifeFromUI = false;
        if (viewModel == null) return;
        viewModel.loadLife();
    }

    private void updateCurrentLifeFromUIUnity() {
        if (!updateCurrentLife) return;
        updateCurrentLife = false;
        updateCurrentStructureLife(currentLife);
    }

    private void updateStructureLifeFromUIUnity() {
        if (!updateStructureLifeFromUI) return;
        updateStructureLifeFromUI = false;
        updateStructureLife(currentStructure);
    }

    //delegate
    public void notifyLoadLife()
    {
        currentStructure = viewModel.currentStructureLife;
        currentLife = viewModel.currentLife;
        maxLife = viewModel.maxLife;
    }
}
