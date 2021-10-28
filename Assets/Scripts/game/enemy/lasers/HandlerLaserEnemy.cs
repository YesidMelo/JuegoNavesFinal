using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLaserEnemy : MonoBehaviour, HandlerLaserEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;
    public int currentImpact;
    public LaserEnemy currentLaser;
    
    private HandlerLaserEnemyViewModel viewModel = new HandlerLaserEnemyViewModelImpl();

    private void Awake()
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
        currentImpact = viewModel.impactLaser;
        currentLaser = viewModel.currentLaser;
    }

    public void notifyLoadSpacecraft() => currentSpacecraft = viewModel.currentSpacecraft;
}
