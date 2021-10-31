using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerStorageEnemy : MonoBehaviour, HandlerStorageEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;
    public StorageEnemy currentStorage;

    private HandlerStorageEnemyViewModel viewModel = new HandlerStorageEnemyViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
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
        currentStorage = viewModel.currentStorage;
    }
}
