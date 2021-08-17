using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameUIListener : NewGameUIDelegate
{

    private UserInterfaceHandlerViewModelDelegate uiDelegate;

    public NewGameUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }

    public void createNewGame() => uiDelegate.goToInteractionGame(new InteractionGameUIListener(uiDelegate));
    
    public void goToBack() => uiDelegate.goToMainMenu(new MainMenuUIListener(uiDelegate));

    public void showProgress() => uiDelegate.showProgress();
}
