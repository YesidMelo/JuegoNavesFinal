using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationSpacecraftUIListener : ConfigurationSpaceCraftUIDelegate
{

    private UserInterfaceHandlerViewModelDelegate uiDelegate;

    public ConfigurationSpacecraftUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }

    public void goToBack()
    {
        uiDelegate.goToInteractionGame(new InteractionGameUIListener(uiDelegate));
    }

    public void goToLasers() => uiDelegate.goToLaserOptions(new LaserOptionsUIListener(uiDelegate));

    public void goToShields() => uiDelegate.goToShieldOption(new ShieldOptionsUIListener(uiDelegate));

    public void showProgress() => uiDelegate.showProgress();
}
