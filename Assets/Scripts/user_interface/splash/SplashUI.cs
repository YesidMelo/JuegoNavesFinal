using UnityEngine;

// Class that manage ui of splash
public class SplashUI : AbstractCanvas, SplashUIViewModelDelegate
{
    public SplashUIDelegate myDelegate;
    public SplashUIViewModel splashUIViewModel = new SplashUIViewModelImpl();

    void Start() {
        splashUIViewModel.myDelegate = this;
        onClickContinue();
    }

    // public methods
    // Method that listen action click on button
    public async void onClickContinue() {
       await splashUIViewModel.goToMainMenu();
    }

    // inherit of delegates
    public void goToMainMenu()
    {
        if (myDelegate == null) { return; }
        myDelegate.goToMainMenu();
    }

}

// interface that manage response in ui splash
public interface SplashUIDelegate {

    // method that notifies go to main menu
    void goToMainMenu();
}