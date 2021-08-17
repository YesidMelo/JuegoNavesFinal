using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameUIListener : LoadGameUIDelegate
{

    private UserInterfaceHandlerViewModelDelegate uiDelegate;

    public LoadGameUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }

    public void goToBack() => uiDelegate.goToMainMenu(new MainMenuUIListener(uiDelegate));

    public void goToInteractionGame() => uiDelegate.goToInteractionGame(new InteractionGameUIListener(uiDelegate));
    public void showProgress() => uiDelegate.showProgress();
}
