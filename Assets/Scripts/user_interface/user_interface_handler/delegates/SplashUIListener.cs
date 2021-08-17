using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashUIListener : SplashUIDelegate
{
    private UserInterfaceHandlerViewModelDelegate uiDelegate;
    public SplashUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }

    public void goToMainMenu() => uiDelegate.goToMainMenu(new MainMenuUIListener(uiDelegate));
}
