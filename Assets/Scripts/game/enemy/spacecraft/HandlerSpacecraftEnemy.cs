using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerSpacecraftEnemy : MonoBehaviour, HandlerSpacecraftEnemyViewModelDelegate
{
    public bool loadSpacecraftFromUi = false;
    public bool updateSpacecraftFromUI = false;
    public SpacecraftEnemy currentSpacecraft = SpacecraftEnemy.SPACECRAFT_1;


    private HandlerSpacecraftEnemyViewModel viewModel = new HandlerSpacecraftEnemyViewModelImpl();

    void Start()
    {
        viewModel.myDelegate = this;
        viewModel.loadSpacecraft();
    }

    // Update is called once per frame
    void Update()
    {
        loadFromUIUnity();
        updateFromUIUnity();
    }

    //public methods
    public void updateSpacecraft(SpacecraftEnemy spacecraft) {
        if (viewModel == null) return;
        viewModel.setSpacecraft(spacecraft);
    }

    //private methods
    //ui unity
    private void loadFromUIUnity() {
        if (!loadSpacecraftFromUi) return;
        loadSpacecraftFromUi = false;
        viewModel.loadSpacecraft();
    }

    private void updateFromUIUnity() {
        if (!updateSpacecraftFromUI) return;
        updateSpacecraftFromUI = false;
        updateSpacecraft(currentSpacecraft);
    }

    //delegates
    public void notifyLoadEnemy()
    {
        currentSpacecraft = viewModel.currentSpacecraft;
    }
}
