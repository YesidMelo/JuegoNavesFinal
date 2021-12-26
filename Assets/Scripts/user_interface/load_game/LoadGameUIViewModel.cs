using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGameUIViewModelDelegate {
    void goToBack();
    void goToInteractionGame();
}
public interface LoadGameUIViewModel {
    LoadGameUIViewModelDelegate myDelegate { set; }
    Task loadListGames();
    string title { get; }
    string back { get; }
    string load { get; }

    void goBack();
    Task loadGame();
}

public class LoadGameUIViewModelImpl : LoadGameUIViewModel
{
    private CurrentLangajeUseCase currentLangajeUseCase = new CurrentLangajeUseCaseImpl();
    private LoadGamesSavesUseCase loadGamesSavesUseCase = new LoadGamesSavesUseCaseImpl();

    private LoadGameUIViewModelDelegate _myDelegate;
    public LoadGameUIViewModelDelegate myDelegate { set => _myDelegate = value; }

    public string title => currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.LOAD_GAME);

    public string back => currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.GO_BACK);

    public string load => currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.LOAD);

    public void goBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

    public async Task loadListGames() {
        List<GameModel> listGames = await loadGamesSavesUseCase.invoke();
        Debug.Log("");
    }

    public async Task loadGame()
    {
        if (notExistsDelegate()) { return; }
        
        _myDelegate.goToInteractionGame();
    }

    // private methods
    private bool notExistsDelegate() => _myDelegate == null;
}
