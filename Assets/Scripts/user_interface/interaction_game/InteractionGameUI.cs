using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface InteractionGameUIDelegate : AbstractCanvasUIDelegate
{
    void goToPause();
    void goToConfigSpacecraft();
}


public class InteractionGameUI : AbstractCanvas, InteractionGameUIViewModelDelegate
{

    public InteractionGameUIDelegate myDelegate { set { _myDelegate = value; } }

    private InteractionGameUIDelegate _myDelegate;
    private InteractionGameUIViewModel viewModel = new InteractionGameUIViewModelImpl();

    public GameObject prefabPlayer;


    private void Awake()
    {
        GameObject currentPlayer = Instantiate(prefabPlayer, viewModel.getInitialPosition, Quaternion.identity);
        currentPlayer.transform.name = Constants.namePlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
    }

    // clicks
    public void clickMoveToUp() => viewModel.moveUp();

    public void clickMoveToDown() => viewModel.stop();

    public void clickMoveToLeft() => viewModel.moveLeft();

    public void clickMoveToRight() => viewModel.moveRight();

    public void clickPause() => viewModel.goToPause();

    public void clickConfig() => viewModel.goToConfigSpaceCraft();

    public void clickChangeEnemy() => viewModel.changeEnemy();

    public void clickChangeAction() => viewModel.changeAction();

    public void clickChangeLaser() => viewModel.changeLaser();

    // private methods

    private bool notExistsDelegate() => _myDelegate == null;


    // delegates
    public void goToPause()
    {
        if (notExistsDelegate()) { return;  }
        _myDelegate.goToPause();
    }

    public void goToConfig()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToConfigSpacecraft();
    }

}
