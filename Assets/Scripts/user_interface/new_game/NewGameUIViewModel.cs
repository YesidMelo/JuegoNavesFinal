using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface NewGameUIViewModelDelegate {
    void createNewGame(string name);
    void goToBack();

}

public interface NewGameUIViewModel {
    string title { get; }
    string back { get; }
    string create { get; }

    string placeholder { get; }


    NewGameUIViewModelDelegate myDelegate { set; }

    void createNewGame(NewGameModel newGame);
    void goToBack();
}

public class NewGameUIViewModelImpl : NewGameUIViewModel
{
    private NewGameSetNewGameModelUseCase setNewGameModelUseCase = new NewGameSetNewGameModelUseCaseImpl();
    private NewGameGetCurrentNewGameModelUseCase getCurrentNewGameModelUseCase = new NewGameGetCurrentNewGameModelUseCaseImpl();
    private CurrentLangajeUseCase currentLangajeUseCase = new CurrentLangajeUseCaseImpl();

    private NewGameUIViewModelDelegate _myDelegate;
    private AbstractLanguage _currentLanguaje;

    public NewGameUIViewModelImpl() {
        _currentLanguaje = currentLangajeUseCase.invoke();
    }

    //set and gets
    public NewGameUIViewModelDelegate myDelegate { set => _myDelegate = value; }

    public string title => _currentLanguaje.getNameTag(NameTagLanguage.NEW_GAME);

    public string back => _currentLanguaje.getNameTag(NameTagLanguage.GO_BACK);

    public string create => _currentLanguaje.getNameTag(NameTagLanguage.CREATE_GAME);

    public string placeholder => _currentLanguaje.getNameTag(NameTagLanguage.PLACEHOLDER_NEW_GAME_PLAYER);

    // public methods

    public void createNewGame(NewGameModel newGame)
    {
        Task.Run(async () => {
            if (notExistsDelegate()) { return; }
            bool saved = await setNewGameModelUseCase.invoke(newGame: newGame);
            if (!saved) return;
            NewGameModel gameSaved = await getCurrentNewGameModelUseCase.invoke();
            _myDelegate.createNewGame(string.Format(
                _currentLanguaje.getNameTag(NameTagLanguage.GAME_CREATED),
                gameSaved.namePlayer,
                gameSaved.date.ToString()
            ));
        });
        
        //_myDelegate.createNewGame(name);
    }

    public void goToBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

    // private methods
    private bool notExistsDelegate() {
        return _myDelegate == null;
    }
}
