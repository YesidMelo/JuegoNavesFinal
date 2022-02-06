using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportPlayerUI : MonoBehaviour, LifeSupportPlayerUIViewModelDelegate
{
    public LifeSupportPlayer currentLifeSupport;
    public bool playerIsUnderAttack;
    public bool lifeIsMaxLife;
    public bool runRestoreLife;


    private LifeSupportPlayerUIViewModel _viewModel = new LifeSupportPlayerUIViewModelImpl();

    // Start is called before the first frame update
    void Start()
    {
        _viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (_viewModel == null) return;
        checkCurrentTypeLifeSupport();
        checkPlayerIsUnderAttack();
        checkLifeIsMaxLife();
        restoreLife();
    }

    //private methods
    private void checkCurrentTypeLifeSupport() => currentLifeSupport = _viewModel.getCurrentLifeSupport;

    private void checkPlayerIsUnderAttack() => playerIsUnderAttack = _viewModel.playerIsUnderAttack;

    private void checkLifeIsMaxLife() => lifeIsMaxLife = _viewModel.lifeIsMaxLife;

    private void restoreLife() => _viewModel.restoreLife();
}
