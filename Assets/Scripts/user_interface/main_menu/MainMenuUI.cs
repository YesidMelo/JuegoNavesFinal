using TMPro;
using UnityEngine;

public interface MainMenuUIDelegate : AbstractCanvasUIDelegate
{
    void goToAbout();
    void goToConfiguration();
    void goToLoadGame();
    void goToNewGame();
}

public class MainMenuUI : AbstractCanvas, MainMenuUIViewModelDelegate
{
    public TextMeshProUGUI about;
    public TextMeshProUGUI configuration;
    public TextMeshProUGUI loadGame;
    public TextMeshProUGUI newGame;

    public MainMenuUIDelegate myDelegate;
    private MainMenuUIViewModel viewModel = new MainMenuUIViewModelImpl();

    void Start() {
        viewModel.myDelegate = this;
        initValues();
    }


    //private methods

    void initValues() {
        about.text = viewModel.about;
        configuration.text = viewModel.configuration;
        loadGame.text = viewModel.loadGame;
        newGame.text = viewModel.newGame;
    }

    //public method
    public void clickGoToAbout()
    {
        viewModel.goToAbout();
    }

    public void clickGoToConfiguration()
    {
        viewModel.goToConfiguration();
    }

    public void clickGoToLoadGame()
    {
        viewModel.goToLoadGame();
    }

    public void clickGoToNewGame()
    {
        viewModel.goToNewGame();
    }

    // private methods
    private bool notExistsDelegate() {
        return myDelegate == null;
    }

    // delegate

    public void goToAbout()
    {
        if (notExistsDelegate()) { return; }
        myDelegate.goToAbout();
    }

    public void goToConfiguration()
    {
        if (notExistsDelegate()) { return; }
        myDelegate.goToConfiguration();
    }

    public void goToLoadGame()
    {
        if (notExistsDelegate()) { return; }
        myDelegate.goToLoadGame();
    }

    public void goToNewGame()
    {
        if (notExistsDelegate()) { return; }
        myDelegate.goToNewGame();
    }

    //set and gets

}
