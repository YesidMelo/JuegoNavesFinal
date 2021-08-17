public class AboutUIListener : AboutUIDelegate
{

    private UserInterfaceHandlerViewModelDelegate uiDelegate;

    public AboutUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    ) {
        this.uiDelegate = uiDelegate;
    }

    public void goBack() => uiDelegate.goToMainMenu(new MainMenuUIListener(uiDelegate));
    public void showProgress() => uiDelegate.showProgress();

}
