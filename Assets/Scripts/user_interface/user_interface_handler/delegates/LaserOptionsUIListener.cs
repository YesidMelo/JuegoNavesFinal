public class LaserOptionsUIListener : LaserOptionsUIDelegate
{
    private UserInterfaceHandlerViewModelDelegate uiDelegate;

    public LaserOptionsUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }
    public void goBack() => uiDelegate.goToConfigurationSpacecraft(new ConfigurationSpacecraftUIListener(uiDelegate));

    public void showProgress() => uiDelegate.showProgress();
}
