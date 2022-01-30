using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public interface InteractionGameUIDelegate : AbstractCanvasUIDelegate
{
    void goToPause();
    void goToConfigSpacecraft();
    void goToGameOver();
}


public class InteractionGameUI : AbstractCanvas, InteractionGameUIViewModelDelegate
{

    public InteractionGameUIDelegate myDelegate { set { _myDelegate = value; } }

    private InteractionGameUIDelegate _myDelegate;
    private InteractionGameUIViewModel viewModel = new InteractionGameUIViewModelImpl();

    
    public VariableJoystick joystic;
    public TextMeshProUGUI textAction;
    public TextMeshProUGUI textLife;
    public TextMeshProUGUI textChangeLevel;
    public Button buttonChangeLevel;


    // lifecycle
    private void FixedUpdate()
    {
        updateMovementJoystic();
        updateTexts();
    }

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
        viewModel.currentStatusGame = StatusGame.IN_GAME;
    }

    private void Update()
    {
        viewModel.checkIsGameOver();
        checkPlayerInPortal();
    }



    // clicks


    public void clickPause() => viewModel.goToPause();

    public void clickConfig() => viewModel.goToConfigSpaceCraft();

    public void clickChangeEnemy() => viewModel.changeEnemy();

    public void clickChangeAction() => viewModel.changeAction();

    public void clickChangeLaser() => viewModel.changeLaser();
    public void clickChangeLevel() => viewModel.changeLevel();

    // private methods

    private bool notExistsDelegate() => _myDelegate == null;

    private void updateMovementJoystic() {
        Vector2 direction = joystic.Direction;
        viewModel.updateDirectionJoystic(direction);
    }

    private void updateTexts()
    {
        textAction.text = viewModel.textButtonAction;
        textLife.text = viewModel.textLife;
        textChangeLevel.text = viewModel.textChangeLevel;
    }

    private void checkPlayerInPortal() {

        if (!viewModel.isPlayerInPortal || viewModel.currentPortal == null) {
            buttonChangeLevel.gameObject.hidden();
            return;
        }
        
        buttonChangeLevel.gameObject.show();
    }


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

    public void goToGameOver() {
        if (notExistsDelegate()) return;
        _myDelegate.goToGameOver();
    }

    public Vector3 getInitialPosition {
        get => viewModel.getInitialPosition;
    }

}
