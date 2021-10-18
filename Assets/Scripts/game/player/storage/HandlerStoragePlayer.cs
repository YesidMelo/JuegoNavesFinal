using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerStoragePlayer : MonoBehaviour, HandlerStoragePlayerViewModelDelegate
{
    public StoragePlayer currentStorage = StoragePlayer.TYPE_2;
    public bool loadStorageUI = false;
    public bool updateStorageUI = false;

    private HandlerStoragePlayerViewModel viewModel = new HandlerStoragePlayerViewModelImpl();
    private bool updateStorageFromViewModel = false;


    void Start()
    {
        viewModel.myDelegate = this;
        viewModel.loadStorage();
    }

    
    void Update()
    {
        loadStorageFromUIUnity();
        updateStorageFromIUUnity();
        updatedStorage();
    }

    //public methods
    public void updateStorage(StoragePlayer storage) {
        if (viewModel == null) return;
        viewModel.updateStorage(storage);
    }

    //private methods
    private void updatedStorage() {
        if (!updateStorageFromViewModel) return;
        updateStorageFromViewModel = false;
        if (viewModel == null) return;
        currentStorage = viewModel.currentStorage;
    }

    //uiMethods
    private void loadStorageFromUIUnity() {
        if (!loadStorageUI) return;
        loadStorageUI = false;
        if (viewModel == null) return;
        viewModel.loadStorage();
    }

    private void updateStorageFromIUUnity() {
        if (!updateStorageUI) return;
        updateStorageUI = false;
        updateStorage(currentStorage);
    }


    //deletate
    public void notifyLoadStorage()
    {
        updateStorageFromViewModel = true;
    }
}
