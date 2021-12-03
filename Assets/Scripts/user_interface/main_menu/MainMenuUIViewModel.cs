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

    private CurrentLangajeUseCase langajeUseCase = new CurrentLangajeUseCaseImpl();

    public MainMenuUIViewModelDelegate _myDelegate;

    public AbstractLanguage currentLanguage;

    public MainMenuUIViewModelImpl() {
        currentLanguage = langajeUseCase.invoke();
    }

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
        get { return currentLanguage.getNameTag(NameTagLanguage.ABOUT); }
    }
    public string configuration {
        get { return currentLanguage.getNameTag(NameTagLanguage.CONFIGURATION); }
    }
    public string loadGame
    {
        get { return currentLanguage.getNameTag(NameTagLanguage.CONFIGURATION); }
    }

    public string nameGame {
        get { return currentLanguage.getNameTag(NameTagLanguage.NAME_GAME); }
    }

    public string newGame {
        get { return currentLanguage.getNameTag(NameTagLanguage.NEW_GAME); }
    }

    public MainMenuUIViewModelDelegate myDelegate {
        set { _myDelegate = value; }
    }

}