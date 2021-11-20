using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRadarEnemy : MonoBehaviour, HandlerRadarEnemyViewModelDelegate
{
    public SpacecraftEnemy currentSpacecraf;
    public RadarEnemy currentRadar;
    public int currentRadiusRadar;
    public GameObject laserEnemy;
    public List<GameObject> currentListInRadar;
    public CircleCollider2D circleCollider;

    private HandlerRadarEnemyViewModel viewModel = new HandlerRadarEnemyViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!checkCollision(collision)) return;
        viewModel.addGameObjectToRadar(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!checkCollision(collision)) return;
        viewModel.removeGameObjectFromRadar(collision.gameObject);
    }

    //public method
    public void loadCurrentSpacecraft(IdentificatorModel identificator) {
        if (viewModel == null) return;
        viewModel.loadSpacecraft(identificator);
    }

    //private method
    private bool checkCollision(Collider2D collision) {
        Debug.Log(string.Format("nombre : {0}", collision.name));
        if (viewModel == null) return false;
        if (laserEnemy == collision.gameObject) return false;
        if (collision.name.Contains(Constants.nameAmmunitionLaserEnemy)) return false;
        if (collision.name.Contains(Constants.nameAmmunitionLaserPlayer)) return false;
        if (collision.name.Contains(Constants.nameShieldEnemy)) return false;
        if (collision.name.Contains(Constants.nameRadarPlayer)) return false;
        if (collision.name.Contains(Constants.nameLaserPlayer)) return false;
        if (collision.name.Contains(Constants.nameRadarEnemy)) return false;
        if (collision.name.Contains(Constants.nameLaserEnemy)) return false;
        return true;
    }

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
        if (circleCollider == null) return;
        circleCollider.radius = currentRadiusRadar;
    }

    public IdentificatorModel identificator {
        get => viewModel.identificator;
    }
}
