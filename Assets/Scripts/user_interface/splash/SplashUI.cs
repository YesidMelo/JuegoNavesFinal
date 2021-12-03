using UnityEngine;
using TMPro;

// Class that manage ui of splash
public class SplashUI : AbstractCanvas, SplashUIViewModelDelegate
{
    public TextMeshProUGUI nameGame;

    public SplashUIDelegate myDelegate;
    public SplashUIViewModel viewModel = new SplashUIViewModelImpl();

    void Start() {
        viewModel.myDelegate = this;
        onClickContinue();
        loadNameGame();
    }

    // public methods
    

    // inherit of delegates
    public void goToMainMenu()
    {
        if (myDelegate == null) { return; }
        myDelegate.goToMainMenu();
    }

    //private methods
    // Method that listen action click on button
    private async void onClickContinue()
    {
        await viewModel.goToMainMenu();
    }

    private async void loadNameGame() {
        nameGame.text = await viewModel.getNameGame();
    }

}

// interface that manage response in ui splash
public interface SplashUIDelegate {

    // method that notifies go to main menu
    void goToMainMenu();
}