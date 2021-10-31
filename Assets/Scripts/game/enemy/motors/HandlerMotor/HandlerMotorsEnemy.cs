using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerMotorsEnemy : MonoBehaviour, HandlerMotorsEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;
    public MotorEnemy currentMotor;
    public float currentSpeed;

    private HandlerMotorsEnemyViewModel viewModel = new HandlerMotorsEnemyViewModelImpl();

    private void Awake()
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

    public IdentificatorModel identificator {
        get {
            return viewModel.identificator;
        }
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
        currentMotor = viewModel.currentMotor;
        currentSpeed = viewModel.currentSpeed;
    }
}
