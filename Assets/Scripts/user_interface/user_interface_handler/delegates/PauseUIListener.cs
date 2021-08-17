using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIListener : PauseUIDelegate
{

    private UserInterfaceHandlerViewModelDelegate uiDelegate;

    public PauseUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }

    public void goContinue() => uiDelegate.goToInteractionGame(new InteractionGameUIListener(uiDelegate));

    public void goSaveAndExit() => uiDelegate.goToMainMenu(new MainMenuUIListener(uiDelegate));

    public void showProgress() => uiDelegate.showProgress();
}
