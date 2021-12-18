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
    Task<bool> createDatabase(string applicationDataPath);
    Task<bool> createTablesDataBase();
    void splashDestroyed();
}

// class that manage actions in splash ui
public class SplashUIViewModelImpl : SplashUIViewModel
{
    private CurrentLangajeUseCase langajeUseCase = new CurrentLangajeUseCaseImpl();
    private SplashLoadElementsUseCase loadElementsUseCase = new SplashLoadElementsUseCaseImpl();
    private CreateDataBaseUseCase createDataBaseUseCase = new CreateDataBaseUseCaseImpl();
    private CreateTablesDBUseCase createTablesDBUseCase = new CreateTablesDBUseCaseImpl();

    private SplashUIViewModelDelegate _myDelegate;
    private bool splashDestroyed = true;
    public SplashUIViewModelImpl() { }

    public  async Task goToMainMenu() {
        if (_myDelegate == null) return;
        splashDestroyed = false;
        bool output = await loadElementsUseCase.invoke();
        if (!output) return;
        if (splashDestroyed) return;
        _myDelegate.goToMainMenu();
    }

    public async Task<string> getNameGame()
    {
        return await Task.Run(() => {
            return langajeUseCase.invoke().getNameTag(NameTagLanguage.NAME_GAME);
        });
    }

    public async Task<bool> createDatabase(string applicationDataPath) => await createDataBaseUseCase.invoke(applicationDataPath: applicationDataPath);
    public async Task<bool> createTablesDataBase() => await createTablesDBUseCase.invoke();

    void SplashUIViewModel.splashDestroyed() => splashDestroyed = true;

    //sets and gets
    public SplashUIViewModelDelegate myDelegate { set => _myDelegate = value; }
}
