using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerShieldPlayer : MonoBehaviour, HandlerShieldPlayerViewModelDelegate
{
    public ShieldPlayer shield;
    public bool updateShield = false;
    public bool loadCurrrentShield = true;
    private HandlerShieldPlayerViewModel viewModel = new HandlerShieldPlayerViewModelImpl();

    

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    void Update()
    {
        updateShieldFromUI();
        loadShieldFromUI();
    }

    //public methods
    public void loadShield() {
        loadShieldFromUI();
    }

    //private methods
    //ui methods
    private void updateShieldFromUI() {
        if (!updateShield) return;
        updateShield = false;
        viewModel.updateShield(shield);
    }
    private void loadShieldFromUI() {
        if (!loadCurrrentShield) return;
        loadCurrrentShield = true;
        viewModel.loadShield();
    }
    //delegates

    public void notifyLoadShield()
    {
        loadCurrrentShield = false;
        shield = viewModel.currentShield;
    }
}
