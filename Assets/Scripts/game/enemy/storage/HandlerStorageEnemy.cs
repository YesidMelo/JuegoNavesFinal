using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerStorageEnemy : MonoBehaviour, HandlerStorageEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;

    private HandlerStorageEnemyViewModel viewModel = new HandlerStorageEnemyViewModelImpl();

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
    public void loadSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadSpacecraf(identificator);
    }
    //private methods
    //ui methods
    //delegates
    public void notifyLoadCurrentSpacecraft()
    {
        currentSpacecraft = viewModel.currentSpacecraft;
    }

    public void notifyLoadStorage()
    {
        
    }
}
