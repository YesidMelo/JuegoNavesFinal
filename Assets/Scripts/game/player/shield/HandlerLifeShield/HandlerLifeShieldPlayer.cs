using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandlerLifeShieldPlayer : MonoBehaviour, HandlerLifeShieldPlayerViewModelDelegate
{
    public HandlerShieldPlayer handlerShieldPlayer;

    private HandlerLifeShieldPlayerViewModel viewModel = new HandlerLifeShieldPlayerViewModelImpl();

    private void Awake()
    {
        viewModel.myDelegate = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.name.Contains(Constants.nameAmmunitionLaserEnemy)) return;
        viewModel.removeLife(collision);
        Destroy(collision.gameObject);
    }

    //public methods
    //private methods
    //ui methods
    //delegates
}
