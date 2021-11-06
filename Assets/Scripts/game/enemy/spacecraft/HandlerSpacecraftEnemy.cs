using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerSpacecraftEnemy : MonoBehaviour, HandlerSpacecraftEnemyViewModelDelegate
{
    public bool loadSpacecraftFromUi = false;
    public bool updateSpacecraftFromUI = false;
    public SpacecraftEnemy currentSpacecraft = SpacecraftEnemy.NIVEL1_SPACECRAFT1;
    public HandlerLaserEnemy handlerLaserEnemy;
    public HandlerMotorsEnemy handlerMotorsEnemy;
    public HandlerLifeEnemy handlerLifeEnemy;
    public HandlerRadarEnemy handlerRadarEnemy;
    public HandlerShieldEnemy handlerShieldEnemy;
    public HandlerStorageEnemy handlerStorageEnemy;
    public HandlerStructureEnemy handlerStructureEnemy;
    public bool isLoadSpacecraftFromViewModel = false;

    private HandlerSpacecraftEnemyViewModel viewModel = new HandlerSpacecraftEnemyViewModelImpl();

    private void Start()
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

    private void OnDestroy()
    {
        if (viewModel == null) return;
        viewModel.destroySpacecraft();
    }

    //public methods
    public void updateSpacecraft(SpacecraftEnemy spacecraft) {
        if (viewModel == null) return;
        viewModel.setSpacecraft(spacecraft);
    }

    //private methods
    private void loadLasers() {
        if (handlerLaserEnemy == null) return;
        handlerLaserEnemy.loadCurrentSpacecraft(viewModel.identificator);
    }

    private void loadLife() {
        if (handlerLifeEnemy == null) return;
        handlerLifeEnemy.loadCurrentSpacecraft(viewModel.identificator);
        handlerLifeEnemy.listenerLifeZero = (float currentLife)=>{
            if (!isLoadSpacecraftFromViewModel) return;
            Destroy(transform.gameObject); 
        };
    }

    private void loadMotors() {
        if (handlerMotorsEnemy == null) return;
        handlerMotorsEnemy.loadSpacecraft(viewModel.identificator);
    }

    private void loadRadar() {
        if (handlerRadarEnemy == null) return;
        handlerRadarEnemy.loadCurrentSpacecraft(viewModel.identificator);
    }

    private void loadShield() {
        if (handlerShieldEnemy == null) return;
        handlerShieldEnemy.loadCurrentSpacecraft(viewModel.identificator);
    }

    private void loadStorage() {
        if (handlerStorageEnemy == null) return;
        handlerStorageEnemy.loadSpacecraft(viewModel.identificator);
    }

    private void loadStructure() {
        if (handlerStructureEnemy == null) return;
        handlerStructureEnemy.loadSpacecraft(viewModel.identificator);
    }

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
        loadLasers();
        loadMotors();
        loadLife();
        loadRadar();
        loadShield();
        loadStorage();
        loadStructure();
        isLoadSpacecraftFromViewModel = true;
    }
}
