using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerMotorsEnemy : MonoBehaviour, HandlerMotorsEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;
    private HandlerMotorsEnemyViewModel viewModel = new HandlerMotorsEnemyViewModelImpl();
    
    void Start()
    {
        viewModel.myDelegate = this;    
    }

    void Update()
    {
        
    }

    //public methods
    public void loadSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadSpacecraft(identificator);
    }

    //private methods
    //ui Methods
    //delegate
    public void notifyLoadCurrentSpacecraft()
    {
        currentSpacecraft = viewModel.currrentSpacecraft;
    }

    public void notifyLoadMotor()
    {
        
    }
}
