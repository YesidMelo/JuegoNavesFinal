using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLaserEnemy : MonoBehaviour, HandlerLaserEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;
    
    private HandlerLaserEnemyViewModel viewModel = new HandlerLaserEnemyViewModelImpl();
    

    void Start()
    {
        viewModel.myDelegate = this;    
    }

    //public methods
    public void loadCurrentSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadCurrentSpacecraft(identificator);
    }

    //private methods
    //ui unity
    //delegates
    public void notifyLoadLasers()
    {
        
    }

    public void notifyLoadSpacecraft() => currentSpacecraft = viewModel.currentSpacecraft;
}
