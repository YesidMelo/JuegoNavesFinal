using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface PauseUIViewModelDelegate {
    void goContinue();
    void goSaveAndExit();
}

public interface PauseUIViewModel {
    PauseUIViewModelDelegate myDelegate { set; }
    string title { get; }
    string continueText {get;}
    string saveAndExit { get; }

    void goContinue();
    void goSaveAndExit();
}

public class PauseUIViewModelImpl : PauseUIViewModel
{

    private CurrentLangajeUseCase currentLangajeUseCase = new CurrentLangajeUseCaseImpl();
    private SaveGameUseCase saveGameUseCase = new SaveGameUseCaseImpl();
    private ClearLevelUseCase clearLevelUseCase = new ClearLevelUseCaseImpl();

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
        _myDelegate.goContinue();
    }

    public void goSaveAndExit()
    {
        Task.Run( async () => { 
            await saveGameUseCase.invoke();
            await clearLevelUseCase.invoke();
            if (notExistsDelegate()) { return; }
            _myDelegate.goSaveAndExit();
        });
    }

    // private methods

    private bool notExistsDelegate() => _myDelegate == null;
}
