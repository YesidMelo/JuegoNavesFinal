using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UserInterfaceHandlerViewModelDelegate {

    void goToAbout(AboutUIDelegate aboutUIDelegate);
    void goToSplash(SplashUIDelegate splashUIDelegate);

    void goToMainMenu(MainMenuUIDelegate mainMenuUIDelegate);

    void goToNewGame(NewGameUIDelegate newGameUIDelegate);
    void goToInteractionGame(InteractionGameUIDelegate interactionGameUIDelegate);
    void goToConfigurationGame(ConfigurationGameUIDelegate configurationGameUIDelegate);

    void goToPause(PauseUIDelegate pauseUIDelegate);
    void goToConfigurationSpacecraft(ConfigurationSpaceCraftUIDelegate spaceCraftUIDelegate);
    void goToLaserOptions(LaserOptionsUIDelegate laserOptionsUIDelegate);
    void goToShieldOption(ShieldOptionsUIDelegate shieldOptionsUIDelegate);
    void goToLoadGame(LoadGameUIDelegate loadGameUIDelegate);
    void goToGameOver(GameOverUIDelegate gameOverUIDelegate);

    void showProgress();
}

public interface UserInterfaceHandlerViewModel {

    CanvasAvailable currentCanvas { get; }

    UserInterfaceHandlerViewModelDelegate myDelegate { set; }

    void checkCurrentCanvas();

    void setCurrentMainCamera(Camera mainCamera);
}

public class UserInterfaceHandlerViewModelImpl: UserInterfaceHandlerViewModel
{
    private HandlerUserInterfaceSetCurrentMainCameraUseCase setCurrentMainCameraUseCase = new HandlerUserInterfaceSetCurrentMainCameraUseCaseImpl();

    private CanvasAvailable _currentCanvasEnum = CanvasAvailable.SPLASH;
    private UserInterfaceHandlerViewModelDelegate _myDelegate;

    //public methods

    public void checkCurrentCanvas() {
        if (_myDelegate == null) { return; }

        switch (_currentCanvasEnum)
        {
            case CanvasAvailable.SPLASH:
            default:
                _myDelegate.goToSplash(new SplashUIListener(_myDelegate));        
                return;
        }
    }

    public void setCurrentMainCamera(Camera mainCamera)
    {
        setCurrentMainCameraUseCase.invoke(camera: mainCamera);
    }

    //private methods

    //sets and gets

    public CanvasAvailable currentCanvas {
        get { return _currentCanvasEnum; }
    }

    public UserInterfaceHandlerViewModelDelegate myDelegate {
        set { _myDelegate = value; }
    }

}
