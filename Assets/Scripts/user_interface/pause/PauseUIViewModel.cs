using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface PauseUIViewModelDelegate {
    void goContinue();
    void goSaveAndExit();
    void deleteAllEnemies();
    Task deleteCurrentPlayer();
    Task deleteCurrentSpawmPopulation();
}

public interface PauseUIViewModel {
    PauseUIViewModelDelegate myDelegate { set; }
    string title { get; }
    string continueText {get;}
    string saveAndExit { get; }

    void goContinue();
    void goSaveAndExit();

    List<GameObject> getAllElementToDelete();
    GameObject currentPlayer();
    GameObject currentSpawmPopulation();
}

public class PauseUIViewModelImpl : PauseUIViewModel
{

    private CurrentLangajeUseCase currentLangajeUseCase = new CurrentLangajeUseCaseImpl();
    private DeleteCurrentPlayerUseCase deleteCurrentPlayerUseCase = new DeleteCurrentPlayerUseCaseImpl();
    private DeleteCurrentSpawmPopulationUseCase deleteCurrentSpawmPopulationUseCase = new DeleteCurrentSpawmPopulationUseCaseImpl();
    private GetAllEnemiesUseCase getAllEnemiesUseCase = new GetAllEnemiesUseCaseImpl();
    private GetCurrentPlayerUseCase currentPlayerUseCase = new GetCurrentPlayerUseCaseImpl();
    private GetCurrentSpawmPopulationUseCase spawmPopulationUseCase = new GetCurrentSpawmPopulationUseCaseImpl();
    private SaveGameUseCase saveGameUseCase = new SaveGameUseCaseImpl();
    private StagePopulationClearCacheUseCase stagePopulationClearUseCase = new StagePopulationClearCacheUseCaseImpl();
    private StatusGameUpdateStatusUseCase updateStatusUseCase = new StatusGameUpdateStatusUseCaseImpl();

    PauseUIViewModelDelegate _myDelegate;

    public PauseUIViewModelDelegate myDelegate { set => _myDelegate = value; }

    public string title => _currentLanguage.getNameTag(NameTagLanguage.PAUSE);

    public string continueText => _currentLanguage.getNameTag(NameTagLanguage.CONTINUE);

    public string saveAndExit => _currentLanguage.getNameTag(NameTagLanguage.SAVE_AND_EXIT);

    private AbstractLanguage _currentLanguage;

    public PauseUIViewModelImpl() {
        _currentLanguage = currentLangajeUseCase.invoke();
    }

    public void goContinue()
    {
        if (notExistsDelegate()) { return; }
        updateStatusUseCase.invoke(StatusGame.IN_GAME);
        _myDelegate.goContinue();
    }

    public void goSaveAndExit()
    {
        if (notExistsDelegate()) { return; }
        updateStatusUseCase.invoke(StatusGame.PAUSE);

        Task.Run(async () => {
            try
            {
                _myDelegate.deleteAllEnemies();
                await saveGameUseCase.invoke();
                await _myDelegate.deleteCurrentPlayer();
                await _myDelegate.deleteCurrentSpawmPopulation();
                await Task.Delay(100);
                await deleteCurrentPlayerUseCase.invoke();
                await deleteCurrentSpawmPopulationUseCase.invoke();
                await Task.Delay(100);
                await stagePopulationClearUseCase.invoke();
                updateStatusUseCase.invoke(StatusGame.MAIN_MENU);
                _myDelegate.goSaveAndExit();
            }
            catch (Exception e) {
                Debug.Log(e.Message);
            }
        });
    }

    // private methods

    private bool notExistsDelegate() => _myDelegate == null;

    public List<GameObject> getAllElementToDelete() => getAllEnemiesUseCase.invoke();
    public GameObject currentPlayer() => currentPlayerUseCase.invoke();
    public GameObject currentSpawmPopulation() => spawmPopulationUseCase.invoke();
}
