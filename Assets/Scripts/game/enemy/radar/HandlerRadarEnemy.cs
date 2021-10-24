using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRadarEnemy : MonoBehaviour, HandlerRadarEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraf;

    private HandlerRadarEnemyViewModel viewModel = new HandlerRadarEnemyViewModelImpl();

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public method
    public void loadCurrentSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadSpacecraft(identificator);
    }

    //private method

    //ui unity
    //delegate
    public void notifyLoadCurrentSpacecraft()
    {
        currentSpacecraf = viewModel.currentSpacecraft;
    }

    public void notifyLoadRadar()
    {
        
    }
}
