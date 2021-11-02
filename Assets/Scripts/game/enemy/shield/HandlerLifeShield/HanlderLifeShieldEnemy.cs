using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanlderLifeShieldEnemy : MonoBehaviour, HandlerLifeShieldEnemyViewModelDelegate
{
    public HandlerShieldEnemy handlerShieldEnemy;
    public int currentLife;

    private HandlerLifeShieldEnemyViewModel viewModel = new HandlerLifeShieldEnemyViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    void Update()
    {
        checkCurrentLife();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!checkCurrentCollision(collision)) return;
        removeLife(collision);
        Destroy(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!checkCurrentCollision(collision)) return;
    }


    //public methods
    //private methods
    private void checkCurrentLife() {
        if (handlerShieldEnemy == null) return;
        currentLife = viewModel.currentLife(handlerShieldEnemy.identificator);
    }

    private bool checkCurrentCollision(Collider2D collision) {
        if (viewModel == null) return false;
        if (!collision.name.Contains(Constants.nameAmmunitionLaserPlayer)) return false;
        return true;
    }

    private void removeLife(Collider2D collision) {
        HandlerAmmountLaserPlayer handler = collision.transform.GetComponent<HandlerAmmountLaserPlayer>();
        if (handler == null) return;
        viewModel.removeLife(handler.detailLaser, handlerShieldEnemy.identificator);
    }
    //ui methods
    //delegate
}
