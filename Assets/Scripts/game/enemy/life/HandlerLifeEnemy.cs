using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLifeEnemy : MonoBehaviour, HandlerLifeEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;

    private HandlerLifeEnemyViewModel viewModel = new HandlerLifeEnemyViewModelImpl();

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public methods
    public void loadCurrentSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadCurrentSpacecraft(identificator);
    }

    //private methods
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
