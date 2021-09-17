using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionGameUIViewModelDelegate {
    void goToPause();
    void goToConfig();
}

public interface InteractionGameUIViewModel {

    // get and sets

    InteractionGameUIViewModelDelegate myDelegate { set; }
    Move currentMove { set; }
    StatusGame currentStatusGame { set; }
    Action currentAction { set;  }

    Vector3 getInitialPosition { get; }

    // texts
    string textButtonAction { get; }

    // public methods

    void changeAction();
    void changeEnemy();
    void changeLaser();
    void goToPause();
    void goToConfigSpaceCraft();

    void updateDirectionJoystic(Vector2 direction);

}

public class InteractionGameUIViewModelImpl : InteractionGameUIViewModel
{

    private InteractionGameUIViewModelDelegate _myDelegate;
    private CurrentActionSpacecraftUseCase _currentActionSpacecraftUseCase = new CurrentActionSpacecraftUseCaseImpl();
    private CurrentLangajeUseCase _currentLangajeUseCase = new CurrentLangajeUseCaseImpl();
    private Move _currentMove;
    private StatusGame _currentStatusGame;
    private Vector3 _currentPosition = new Vector3(0, 0, 0);
    private UpdateActionSpacecraftUseCase _updateActionSpacecraftUseCase = new UpdateActionSpacecraftUseCaseImpl();
    private UpdateMovementJoysticUseCase _updateMovementJoysticUseCase = new UpdateMovementJoysticUseCaseImpl();

    // get and sets
    public InteractionGameUIViewModelDelegate myDelegate { set => _myDelegate = value; }
    public Move currentMove { set => _currentMove = value; }
    public StatusGame currentStatusGame { set => _currentStatusGame = value; }
    public Action currentAction { set => _updateActionSpacecraftUseCase.invoke(value); }

    public Vector3 getInitialPosition { get { return _currentPosition; } }


    //texts
    public string textButtonAction {
        get {
            switch (_currentActionSpacecraftUseCase.invoke()) {
                case Action.DEFENSE:
                    return _currentLangajeUseCase.invoke().getNameTag(NameTagLanguage.ATTACK);
                default:
                    return _currentLangajeUseCase.invoke().getNameTag(NameTagLanguage.DEFENSE);
            }
        }
    }


    // public methods

    public void changeAction() {
        switch (_currentActionSpacecraftUseCase.invoke()) {
            case Action.ATTACK:
                _updateActionSpacecraftUseCase.invoke(Action.DEFENSE);
                return;
            case Action.DEFENSE:
                _updateActionSpacecraftUseCase.invoke(Action.ATTACK);
                return;
            default:
                _updateActionSpacecraftUseCase.invoke(Action.DEFENSE);
                return;
        }
    }

    public void changeEnemy() {}

    public void changeLaser() {}

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

    public void updateDirectionJoystic(Vector2 direction) => _updateMovementJoysticUseCase.invoke(direction);


    // private methods

    private bool notExistsDelegate() {
        return _myDelegate == null;
    }
}
