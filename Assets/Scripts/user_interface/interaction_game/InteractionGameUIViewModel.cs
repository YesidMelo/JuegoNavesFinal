using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionGameUIViewModelDelegate {
    void goToPause();
    void goToConfig();
}

public interface InteractionGameUIViewModel {

    InteractionGameUIViewModelDelegate myDelegate { set; }

    Move currentMove { set; }
    StatusGame currentStatusGame { set; }
    Action currentAction { set;  }

    Vector3 getInitialPosition { get; }

    void moveUp();
    void stop();
    void moveLeft();
    void moveRight();
    void goToPause();
    void goToConfigSpaceCraft();
    void changeAction();
    void changeEnemy();
    void changeLaser();

}

public class InteractionGameUIViewModelImpl : InteractionGameUIViewModel
{

    private InteractionGameUIViewModelDelegate _myDelegate;
    private Move _currentMove;
    private StatusGame _currentStatusGame;
    private Action _currentAction;
    private Vector3 _currentPosition = new Vector3(0, 0, 0);

    ///Uses cases
    private UpdateCurrentMoveUseCase updateCurrentMoveUseCase = new UpdateCurrentMoveUseCaseImpl();


    public InteractionGameUIViewModelDelegate myDelegate { set => _myDelegate = value; }
    public Move currentMove { set => _currentMove = value; }
    public StatusGame currentStatusGame { set => _currentStatusGame = value; }
    public Action currentAction { set => _currentAction = value; }

    public Vector3 getInitialPosition { get { return _currentPosition; } }

    public void changeAction()
    {
        
    }

    public void changeEnemy()
    {
        
    }

    public void changeLaser()
    {
        
    }

    public void goToConfigSpaceCraft()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToConfig();
    }

    public void goToPause()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToPause();
    }

    public void moveLeft() => updateCurrentMoveUseCase.invoke(Move.LEFT);

    public void moveRight() => updateCurrentMoveUseCase.invoke(Move.RIGT);

    public void moveUp() { 
        updateCurrentMoveUseCase.invoke(Move.TOP); 
    }


    public void stop() => updateCurrentMoveUseCase.invoke(Move.STOP);

    // private methods

    private bool notExistsDelegate() {
        return _myDelegate == null;
    }
}
