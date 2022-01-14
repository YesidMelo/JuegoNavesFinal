public class GameOverUIListener : GameOverUIDelegate 
{
    private UserInterfaceHandlerViewModelDelegate uiDelegate;

    public GameOverUIListener(
        UserInterfaceHandlerViewModelDelegate uiDelegate
    )
    {
        this.uiDelegate = uiDelegate;
    }

    public void goToInteractionGame() => uiDelegate.goToInteractionGame(new InteractionGameUIListener(uiDelegate: uiDelegate));

    public void showProgress() => uiDelegate.showProgress();
}
