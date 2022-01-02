using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public interface LoadGameUIViewModelDelegate {
    void goToBack();
    void goToInteractionGame();

    void showListGameObjectSaved(List<GameModel> gameModels);

}
public interface LoadGameUIViewModel {
    LoadGameUIViewModelDelegate myDelegate { set; }
    Task loadListGames();
    string title { get; }
    string back { get; }
    string load { get; }

    void goBack();
    Task deleteGame(GameModel gameModel);
    Task loadGame(GameModel gameModel);
}

public class LoadGameUIViewModelImpl : LoadGameUIViewModel
{
    private CurrentLangajeUseCase currentLangajeUseCase = new CurrentLangajeUseCaseImpl();
    private LoadGamesSavesUseCase loadGamesSavesUseCase = new LoadGamesSavesUseCaseImpl();
    private LoadGameSavedUseCase loadGameSavedUseCase = new LoadGameSavedUseCaseImpl();

    private LoadGameUIViewModelDelegate _myDelegate;
    public LoadGameUIViewModelDelegate myDelegate { set => _myDelegate = value; }

    public string title => currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.LOAD_GAME);

    public string back => currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.GO_BACK);

    public string load => currentLangajeUseCase.invoke().getNameTag(nameTag: NameTagLanguage.LOAD);

    private SynchronizationContext syncContext = SynchronizationContext.Current;


    public void goBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

    public async Task loadListGames() {
        List<GameModel> listGames = await loadGamesSavesUseCase.invoke();
        if (_myDelegate == null) return;
        syncContext.Post(
            _ => {
                _myDelegate.showListGameObjectSaved(gameModels: listGames);
            }
            , null
        );
    }

    public async Task loadGame(GameModel gameModel)
    {
        if (notExistsDelegate()) { return; }
        await loadGameSavedUseCase.invoke(gameModel: gameModel);
        //_myDelegate.goToInteractionGame();
    }

    public async Task deleteGame(GameModel gameModel) {
        if (notExistsDelegate()) return;
        Debug.Log($"juego eliminar : {gameModel.namePlayer}");
    }

    // private methods
    private bool notExistsDelegate() => _myDelegate == null;
}
