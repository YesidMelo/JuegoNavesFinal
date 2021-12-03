using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public interface SplashUIViewModelDelegate
{
    // Method that go to main menu in ui
    void goToMainMenu();
}

public interface SplashUIViewModel {
    
    Task<string> getNameGame();
    SplashUIViewModelDelegate myDelegate { set; }
    Task goToMainMenu();
}

// class that manage actions in splash ui
public class SplashUIViewModelImpl : SplashUIViewModel
{
    private CurrentLangajeUseCase langajeUseCase = new CurrentLangajeUseCaseImpl();

    private SplashLoadElementsUseCase loadElementsUseCase = new SplashLoadElementsUseCaseImpl();

    private SplashUIViewModelDelegate _myDelegate;
    public SplashUIViewModelImpl() { 

    }

    public  async Task goToMainMenu() {
        if (_myDelegate == null) return;
        bool output = await loadElementsUseCase.invoke();
        if (!output) return;
        _myDelegate.goToMainMenu();
    }

    public async Task<string> getNameGame()
    {
        return await Task.Run(() => {
            return langajeUseCase.invoke().getNameTag(NameTagLanguage.NAME_GAME);
        });
    }


    //sets and gets
    public SplashUIViewModelDelegate myDelegate { set => _myDelegate = value; }
}
