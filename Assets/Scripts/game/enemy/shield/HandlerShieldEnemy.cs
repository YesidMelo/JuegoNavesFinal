using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerShieldEnemy : MonoBehaviour, HandlerShieldEnemyViewModelDelegate
{

    public SpacecraftEnemy currentSpacecraft;

    private HandlerShieldEnemyViewModel viewModel = new HandlerShieldEnemyViewModelImpl();
      

    void Start()
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
        
    }
}
