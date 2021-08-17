using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionGameUIListener : InteractionGameUIDelegate
{

    private UserInterfaceHandlerViewModelDelegate uiDelegate;

    public InteractionGameUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }

    public void goToConfigSpacecraft() => uiDelegate.goToConfigurationSpacecraft(new ConfigurationSpacecraftUIListener(uiDelegate));

    public void goToPause() => uiDelegate.goToPause(new PauseUIListener(uiDelegate));

    public void showProgress() => uiDelegate.showProgress();
}
