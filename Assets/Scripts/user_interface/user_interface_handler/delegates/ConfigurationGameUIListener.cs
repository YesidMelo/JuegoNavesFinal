using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationGameUIListener : ConfigurationGameUIDelegate
{
    private UserInterfaceHandlerViewModelDelegate uiDelegate;

    public ConfigurationGameUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }

    public void goToBack() => uiDelegate.goToMainMenu(new MainMenuUIListener(uiDelegate));
    public void showProgress() => uiDelegate.showProgress();

}
