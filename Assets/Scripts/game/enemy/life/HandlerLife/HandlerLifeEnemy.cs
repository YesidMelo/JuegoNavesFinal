using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLifeEnemy : MonoBehaviour, HandlerLifeEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraft;
    public float maxLife;
    public float currentLife;

    private HandlerLifeEnemyViewModel viewModel = new HandlerLifeEnemyViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        loaDetailLifeSpacecraft();
        checkCurrentScale();
    }

    //public methods
    public void loadCurrentSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadCurrentSpacecraft(identificator);
    }

    //private methods
    private void loaDetailLifeSpacecraft() {
        if (viewModel == null) return;
        maxLife = viewModel.maxLife;
        currentLife = viewModel.currentLife;
    }

    private void checkCurrentScale()
    {
        float percentage = Constants.lifeBarPlayer * (currentLife / maxLife);
        transform.localScale = new Vector3(percentage, Constants.lifeBarPlayer, 0f);
    }

    //ui methods

    //delegates
    public void notifyLoadCurrentLife() { }

    public void notifyLoadCurrentSpacecraft()
    {
        currentSpacecraft = viewModel.currentSpacecraft;
    }
}