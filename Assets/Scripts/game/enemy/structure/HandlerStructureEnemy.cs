using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerStructureEnemy : MonoBehaviour, HandlerStructureEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;

    private HandlerStructureEnemyViewModel viewModel = new HandlerStructureEnemyViewModelImpl();

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
    public void loadSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadSpacecraft(identificator);
    }

    //private methods
    //ui methods
    //delegates

    public void notifyLoadScructure()
    {
        
    }

    public void notifyLoadSpacecraft()
    {
        currentSpacecraft = viewModel.currentSpacecraft;
    }
}
