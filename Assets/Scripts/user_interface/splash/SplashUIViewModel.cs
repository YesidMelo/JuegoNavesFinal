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
    SplashUIViewModelDelegate myDelegate { set; }
    Task goToMainMenu();
}

// class that manage actions in splash ui
public class SplashUIViewModelImpl : SplashUIViewModel
{

    private SplashLoadElementsUseCase loadElementsUseCase = new SplashLoadElementsUseCaseImpl();

    private SplashUIViewModelDelegate _myDelegate;

    public  async Task goToMainMenu() {
        Debug.Log("Inicio hilo");
        if (_myDelegate == null) return;
        bool output = await loadElementsUseCase.invoke();
        Debug.Log("finalizo hilo");
        if (!output) return;
        _myDelegate.goToMainMenu();
    }

    
    //sets and gets
    public SplashUIViewModelDelegate myDelegate { set => _myDelegate = value; }
}
