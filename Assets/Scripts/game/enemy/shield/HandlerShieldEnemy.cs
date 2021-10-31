using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerShieldEnemy : MonoBehaviour, HandlerShieldEnemyViewModelDelegate
{

    public SpacecraftEnemy currentSpacecraft;
    public ShieldEnemy currentShield;

    private HandlerShieldEnemyViewModel viewModel = new HandlerShieldEnemyViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    void Update()
    {
        
    }

    //public methods
    public void loadCurrentSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadSpacecraft(identificator);
    }

    //private methods
    //ui methods
    //delegate
    public void notifyLoadCurrentSpacecraft()
    {
        currentSpacecraft = viewModel.currentSpacecraft;
    }

    public void notifyLoadShield()
    {
        currentShield = viewModel.currentShield;
    }
}
