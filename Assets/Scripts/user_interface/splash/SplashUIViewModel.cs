using Zenject;
public interface SplashUIViewModelDelegate
{
    // Method that go to main menu in ui
    void goToMainMenu();
}

public interface SplashUIViewModel {
    SplashUIViewModelDelegate myDelegate { set; }
    void goToMainMenu();
}

// class that manage actions in splash ui
public class SplashUIViewModelImpl : SplashUIViewModel
{
    private SplashUIViewModelDelegate _myDelegate;

    public void goToMainMenu() {
        if (_myDelegate == null) { return; }
        _myDelegate.goToMainMenu();
    }

    //sets and gets
    public SplashUIViewModelDelegate myDelegate { set => _myDelegate = value; }
}
