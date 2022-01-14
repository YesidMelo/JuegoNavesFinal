using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GameOverUIViewModelDelegate {
    void goToInteractionGame();
}

public interface GameOverUIViewModel {
    string textBack { get; }
    string textGameOver { get; }
    GameOverUIViewModelDelegate myDelegate { set; }
    void restoreSpacecraft();
}

public class GameOverUIViewModelImpl : GameOverUIViewModel {

    private CurrentLangajeUseCase currentLangajeUseCase = new CurrentLangajeUseCaseImpl();
    private StatusGameRestoreSpacecraftUseCase restoreSpacecraftUseCase = new StatusGameRestoreSpacecraftUseCaseImpl();

    public GameOverUIViewModelDelegate myDelegate { set { _myDelegate = value; } }

    private GameOverUIViewModelDelegate _myDelegate;

    public string textBack => currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.GO_BACK);

    public string textGameOver => currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.GAME_OVER);

    public void restoreSpacecraft() {
        if (_myDelegate == null) return;
        restoreSpacecraftUseCase.invoke();
        _myDelegate.goToInteractionGame();
    }
}