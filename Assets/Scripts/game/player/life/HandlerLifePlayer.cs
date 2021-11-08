using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLifePlayer : MonoBehaviour, HandlerLifePlayerViewModelDelegate
{
    public StructurePlayer currentStructure = StructurePlayer.TYPE_1;
    public bool loadLifeFromUI = false;
    public bool updateStructureLifeFromUI = false;
    public bool updateCurrentLife = false;
    public float maxLife = 0;
    public float currentLife = 0;
    public GameObject parent;

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
        checkCurrentLife();
        checkCurrentScale();
    }

    //public methods
    public void updateStructureLife(StructurePlayer structure) {
        if (viewModel == null) return;
        viewModel.setStructurePlayer(structure);
        
    }

    public void updateCurrentStructureLife(float currentLife) {
        if (viewModel == null) return;
        viewModel.updateCurrentLife(currentLife);
    }

    //private methods
    private void checkCurrentLife() {
        currentLife = viewModel.currentLife;
        maxLife = viewModel.maxLife;
    }

    private void checkCurrentScale() {
        transform.localScale = new Vector3(viewModel.percentage(), Constants.lifeBarPlayer, 0f);
    }

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
        updateCurrentStructureLife(300);
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
    }
}
