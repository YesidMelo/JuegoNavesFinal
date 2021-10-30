using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLifeEnemy : MonoBehaviour, HandlerLifeEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;
    public int maxLife;
    public int currentLife;

    private HandlerLifeEnemyViewModel viewModel = new HandlerLifeEnemyViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        loaDetailLifeSpacecraft();
    }

    //public methods
    public void loadCurrentSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadCurrentSpacecraft(identificator);
    }

    //private methods
    private void loaDetailLifeSpacecraft() {
        if (viewModel == null) return;
        maxLife = viewModel.maxLife;
        currentLife = viewModel.currentLife;
    }
    //ui methods

    //delegates
    public void notifyLoadCurrentLife()
    {
        
    }

    public void notifyLoadCurrentSpacecraft()
    {
        currentSpacecraft = viewModel.currentSpacecraft;
    }
}
