using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIListener : MainMenuUIDelegate
{
    private UserInterfaceHandlerViewModelDelegate uiDelegate;
    public MainMenuUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }

    public void goToAbout() => uiDelegate.goToAbout(new AboutUIListener(uiDelegate));

    public void goToConfiguration() => uiDelegate.goToConfigurationGame(new ConfigurationGameUIListener(uiDelegate));

    public void goToLoadGame() => uiDelegate.goToLoadGame(new LoadGameUIListener(uiDelegate));

    public void goToNewGame() => uiDelegate.goToNewGame(new NewGameUIListener(uiDelegate));
    public void showProgress() => uiDelegate.showProgress();
}
