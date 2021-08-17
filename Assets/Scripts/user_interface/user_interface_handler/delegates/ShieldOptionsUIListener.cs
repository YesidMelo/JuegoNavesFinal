using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOptionsUIListener : ShieldOptionsUIDelegate
{
    private UserInterfaceHandlerViewModelDelegate uiDelegate;
    public ShieldOptionsUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }

    public void goBack() => uiDelegate.goToConfigurationSpacecraft(new ConfigurationSpacecraftUIListener(uiDelegate));

    public void showProgress() => uiDelegate.showProgress();
}
