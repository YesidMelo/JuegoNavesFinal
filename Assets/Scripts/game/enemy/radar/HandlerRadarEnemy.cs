using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRadarEnemy : MonoBehaviour, HandlerRadarEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraf;
    public RadarEnemy currentRadar;
    public int currentRadiusRadar;
    public List<GameObject> currentListInRadar;

    private HandlerRadarEnemyViewModel viewModel = new HandlerRadarEnemyViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (viewModel == null) return;
        viewModel.addGameObjectToRadar(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (viewModel == null) return;
        viewModel.removeGameObjectFromRadar(collision.gameObject);
    }

    //public method
    public void loadCurrentSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadSpacecraft(identificator);
    }

    //private method

    //ui unity
    //delegate
    public void notifyLoadCurrentSpacecraft()
    {
        currentSpacecraf = viewModel.currentSpacecraft;
    }

    public void notifyLoadRadar()
    {
        currentRadar = viewModel.currentRadar;
        currentRadiusRadar = viewModel.currentRadiusRadar;
        currentListInRadar = viewModel.currentGameobjectInRadar;
    }
}
