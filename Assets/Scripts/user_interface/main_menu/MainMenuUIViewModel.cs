public interface MainMenuUIViewModelDelegate {

    void goToNewGame();

    void goToLoadGame();

    void goToConfiguration();

    void goToAbout();
}

public interface MainMenuUIViewModel { 
    string about { get; }
    string configuration { get; }
    string nameGame { get; }
    string newGame { get; }
    string loadGame { get; }
    MainMenuUIViewModelDelegate myDelegate { set; }

    void goToNewGame();

    void goToLoadGame();

    void goToConfiguration();

    void goToAbout();
}

public class MainMenuUIViewModelImpl : MainMenuUIViewModel
{

    public MainMenuUIViewModelDelegate _myDelegate;

    public AbstractLanguage currentLanguage;

    public void goToNewGame() {
        if (notExistDelegate()) { return; }
        _myDelegate.goToNewGame();
    }

    public void goToLoadGame() {
        if (notExistDelegate()) { return; }
        _myDelegate.goToLoadGame();
    }

    public void goToConfiguration() {
        if (notExistDelegate()) { return; }
        _myDelegate.goToConfiguration();
    }

    public void goToAbout() {
        if (notExistDelegate()) { return; }
        _myDelegate.goToAbout();
    }

    //private methods
    private bool notExistDelegate() {
        return _myDelegate == null;
    }

    //gets and sets
    public string about
    {
        get { return "Acerca de"; }
    }
    public string configuration {
        get { return "Confguration"; }
    }
    public string loadGame
    {
        get { return "Cargar juego"; }
    }

    public string nameGame {
        get { return "Juego galactico"; }
    }

    public string newGame {
        get { return "Nuevo juego"; }
    }

    public MainMenuUIViewModelDelegate myDelegate {
        set { _myDelegate = value; }
    }

}