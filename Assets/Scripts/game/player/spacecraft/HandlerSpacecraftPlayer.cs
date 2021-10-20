using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerSpacecraftPlayer : MonoBehaviour, HandlerSpacecraftPlayerViewModelDelegate
{
    public bool boolLoadSpacecraft = false;

    private HandlerSpacecraftPlayerViewModel viewModel = new HandlerSpacecraftPlayerViewModelImpl();
    private bool startCoroutineLoadSpacecraftFromViewModel = false;
    
    void Start()
    {
        viewModel.myDelegate = this;
        loadSpacecraft();
    }

    
    void Update()
    {
        loadSpacecraftFromUIUnity();
    }

    //Public methods
    //Private methods
    private void loadSpacecraft() {
        if (startCoroutineLoadSpacecraftFromViewModel) return;
        Debug.Log("Empezo carga");
        startCoroutineLoadSpacecraftFromViewModel = true;
        StartCoroutine(viewModel.loadSpacecraft());
    }

    //UI Unity
    private void loadSpacecraftFromUIUnity() {
        if (!boolLoadSpacecraft) return;
        boolLoadSpacecraft = false;
        loadSpacecraft();
    }
    //Delegates
    public void notifiesLoadSpacecraft()
    {
        startCoroutineLoadSpacecraftFromViewModel = false;
        Debug.Log("Ha cargado");
    }
}
