using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionGameUIViewModelDelegate {
    void goToPause();
    void goToConfig();
    void goToGameOver();
}

public interface InteractionGameUIViewModel {

    // get and sets

    InteractionGameUIViewModelDelegate myDelegate { set; }
    Move currentMove { set; }
    StatusGame currentStatusGame { set; }
    Action currentAction { set;  }
    bool isPlayerInPortal { get; }
    PortalModel currentPortal { get; }

    Vector3 getInitialPosition { get; }

    // texts
    string textButtonAction { get; }
    string textLife { get; }
    string textChangeLevel { get; }

    // public methods

    void changeAction();
    void changeEnemy();
    void changeLaser();
    void changeLevel();
    void goToPause();
    void goToConfigSpaceCraft();

    void updateDirectionJoystic(Vector2 direction);
    void checkIsGameOver();

}

public class InteractionGameUIViewModelImpl : InteractionGameUIViewModel
{

    private readonly CurrentActionSpacecraftUseCase _currentActionSpacecraftUseCase = new CurrentActionSpacecraftUseCaseImpl();
    private readonly CurrentLangajeUseCase _currentLangajeUseCase = new CurrentLangajeUseCaseImpl();
    private readonly UpdateActionSpacecraftUseCase _updateActionSpacecraftUseCase = new UpdateActionSpacecraftUseCaseImpl();
    private readonly UpdateMovementJoysticUseCase _updateMovementJoysticUseCase = new UpdateMovementJoysticUseCaseImpl();
    private readonly SpacecraftPlayerGetLifeUseCase _spacecraftPlayerGetLifeUseCase = new SpacecraftPlayerGetLifeUseCaseImpl();
    private readonly SpacecraftPlayerChangeCurrentEnemyUseCase _changeCurrentEnemyUseCase = new SpacecraftPlayerChangeCurrentEnemyUseCaseImpl();
    private readonly StatusGameUpdateStatusUseCase updateStatusUseCase = new StatusGameUpdateStatusUseCaseImpl();
    private readonly StatusGameIsGameOverUseCase isGameOverUseCase = new StatusGameIsGameOverUseCaseImpl();
    private readonly PortalIsPlayerInPortalUseCase isPlayerInPortalUseCase = new PortalIsPlayerInPortalUseCaseImpl();
    private readonly PortalGetCurrentPortalPlayerUseCase getCurrentPortalPlayerUseCase = new PortalGetCurrentPortalPlayerUseCaseImpl();

    private InteractionGameUIViewModelDelegate _myDelegate;
    private Move _currentMove;
    private Vector3 _currentPosition = new Vector3(0, 0, 0);

    // get and sets
    public InteractionGameUIViewModelDelegate myDelegate { set => _myDelegate = value; }
    public Move currentMove { set => _currentMove = value; }
    public StatusGame currentStatusGame { set => updateStatusUseCase.invoke(statusGame: value); }
    public Action currentAction { set => _updateActionSpacecraftUseCase.invoke(value); }

    public Vector3 getInitialPosition { get { return _currentPosition; } }


    public InteractionGameUIViewModelImpl() {
        _updateActionSpacecraftUseCase.invoke(Action.DEFENSE);
    }

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

    public string textLife => string.Format(
        _currentLangajeUseCase.invoke().getNameTag(NameTagLanguage.LIFE_PLAYER),
        _spacecraftPlayerGetLifeUseCase.invoke()
    );

    public string textChangeLevel => _currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.CHANGE_LEVEL);

    public bool isPlayerInPortal => isPlayerInPortalUseCase.invoke();

    public PortalModel currentPortal => getCurrentPortalPlayerUseCase.invoke();

    // public methods

    public void changeAction() {
        switch (_currentActionSpacecraftUseCase.invoke()) {
            case Action.ATTACK:
                _updateActionSpacecraftUseCase.invoke(Action.DEFENSE);
                return;
            case Action.DEFENSE:
                _updateActionSpacecraftUseCase.invoke(Action.ATTACK);
                _changeCurrentEnemyUseCase.invoke();
                return;
            default:
                _updateActionSpacecraftUseCase.invoke(Action.DEFENSE);
                return;
        }
    }

    public void changeEnemy() => _changeCurrentEnemyUseCase.invoke();

    public void changeLaser() {}

    public void goToConfigSpaceCraft()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToConfig();
    }

    public void goToPause()
    {
        if (notExistsDelegate()) { return; }
        updateStatusUseCase.invoke(statusGame: StatusGame.PAUSE);
        _myDelegate.goToPause();
    }

    public void updateDirectionJoystic(Vector2 direction) => _updateMovementJoysticUseCase.invoke(direction);

    public void checkIsGameOver() {
        if (_myDelegate == null) return;
        if (!isGameOverUseCase.invoke()) return;
        _myDelegate.goToGameOver();
    }

    public void changeLevel()
    {
        if (!isPlayerInPortal) return;
        if (getCurrentPortalPlayerUseCase.invoke() == null) return;
        updateStatusUseCase.invoke(statusGame: StatusGame.CHANGE_LEVEL);

        //updateLevelUseCase.invoke(getCurrentPortalPlayerUseCase.invoke().levelDestination);
    }

    // private methods

    private bool notExistsDelegate() {
        return _myDelegate == null;
    }

    
}
