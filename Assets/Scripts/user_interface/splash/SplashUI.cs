
using UnityEngine;
using Zenject;

// Class that manage ui of splash
public class SplashUI : AbstractCanvas, SplashUIViewModelDelegate
{
    public SplashUIDelegate myDelegate;
    public SplashUIViewModel splashUIViewModel = new SplashUIViewModelImpl();

    void Start() {
        splashUIViewModel.myDelegate = this;
    }

    // public methods
    // Method that listen action click on button
    public void onClickContinue() {
        splashUIViewModel.goToMainMenu();
    }

    // inherit of delegates
    public void goToMainMenu()
    {
        if (myDelegate == null) { return; }
        myDelegate.goToMainMenu();
    }

    public class Factory : PlaceholderFactory<SplashUI> { }

}

// interface that manage response in ui splash
public interface SplashUIDelegate {

    // method that notifies go to main menu
    void goToMainMenu();
}