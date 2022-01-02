using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface ItemListViewGameSavedDelegate {
    public void deleteGame(GameModel gameModel);
    public void loadGame(GameModel gameModel);
}

public class ItemListViewGameSaved : MonoBehaviour
{
    public RectTransform currentRectTransform;
    public GameModel _currentGameSaved;
    public TextMeshProUGUI nameGame;
    public TextMeshProUGUI delete;

    private CurrentLangajeUseCase currentLangajeUseCase = new CurrentLangajeUseCaseImpl();
    private ItemListViewGameSavedDelegate myDelegate;

    //Monobehavior
    public void Start()
    {
        currentRectTransform.offsetMax = new Vector2(0f, currentRectTransform.offsetMax.y);
    }

    //public methods
    public void setDelegate(ItemListViewGameSavedDelegate myDelegate) {
        this.myDelegate = myDelegate;
    }

    public void setCurrentGameSaved(GameModel gameModel) { 
        _currentGameSaved = gameModel;
        nameGame.text = string.Format(
            currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.GAME_CREATED),
            _currentGameSaved.namePlayer,
            _currentGameSaved.date
        );
        delete.text = currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.DELETE);
    }

    //private methods

    //listeners Buttons

    public void onClickListenerLoadGame() {
        if (myDelegate == null) return;
        myDelegate.loadGame(_currentGameSaved);
    }

    public void onClickListenerDeleteGame() {
        if (myDelegate == null) return;
        myDelegate.deleteGame(_currentGameSaved);
    }

    //sets and gets
    public float heigth() => currentRectTransform.rect.height;
    public float width() => currentRectTransform.rect.width;

}
