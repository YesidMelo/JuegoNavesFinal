using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public interface GameOverUIDelegate : AbstractCanvasUIDelegate {
    void goToInteractionGame();
}

public class GameOverUI : AbstractCanvas, GameOverUIViewModelDelegate
{
    public TextMeshProUGUI textTlitle;
    public TextMeshProUGUI textButtonReloadUGUI;

    //Disparador en hilo principal
    //documentacion en : https://stackoverflow.com/questions/41330771/use-unity-api-from-another-thread-or-call-a-function-in-the-main-thread
    //documentacion en : https://docs.microsoft.com/en-us/dotnet/api/system.threading.synchronizationcontext?view=net-5.0
    private SynchronizationContext syncContext = SynchronizationContext.Current;
    private GameOverUIDelegate _myDelegate;
    private GameOverUIViewModel _viewModel = new GameOverUIViewModelImpl();

    public GameOverUIDelegate myDelegate { set { _myDelegate = value; } }

    //lifeCycle
    private void FixedUpdate()
    {
        updateTexts();
    }
    void Start()
    {
        _viewModel.myDelegate = this;
    }

    //clicks
    public void onClickGoBack() => _viewModel.restoreSpacecraft();

    //private void
    private void updateTexts() {
        textTlitle.text = _viewModel.textGameOver;
        textButtonReloadUGUI.text = _viewModel.textBack;
    }

    public void goToInteractionGame() {
        if (_myDelegate == null) return;
        _myDelegate.goToInteractionGame();
    }
}
