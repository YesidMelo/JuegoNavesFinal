using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using System.Threading;

public interface PauseUIDelegate : AbstractCanvasUIDelegate {
    void goContinue();
    void goSaveAndExit();
}

public class PauseUI : AbstractCanvas, PauseUIViewModelDelegate
{
    //Disparador en hilo principal
    //documentacion en : https://stackoverflow.com/questions/41330771/use-unity-api-from-another-thread-or-call-a-function-in-the-main-thread
    //documentacion en : https://docs.microsoft.com/en-us/dotnet/api/system.threading.synchronizationcontext?view=net-5.0
    private SynchronizationContext syncContext = SynchronizationContext.Current;

    public PauseUIDelegate myDelegate { set { _myDelegate = value; } }
    public TextMeshProUGUI title;
    public TextMeshProUGUI continueText;
    public TextMeshProUGUI saveAndExit;

    private PauseUIViewModel viewModel = new PauseUIViewModelImpl();
    private PauseUIDelegate _myDelegate;

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
        initValues();
    }

    // clicks
    public void onClickContinue()
    {
        viewModel.goContinue();
    }

    public void onClickSaveAndExit() {
        viewModel.goSaveAndExit();
    }

    // private methods
    bool notExistsDelegate() => _myDelegate == null;

    void initValues() {
        title.text = viewModel.title;
        continueText.text = viewModel.continueText;
        saveAndExit.text = viewModel.saveAndExit;
    }

    // delegate

    public void goContinue()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goContinue();
    }

    public void goSaveAndExit()
    {
        if (notExistsDelegate()) { return; }
        syncContext.Post(_ => { 
            _myDelegate.goSaveAndExit();
        }, null);
    }

    public async Task deleteAllEnemies()
    {
        List<GameObject> currentListEnemies = viewModel.getAllElementToDelete();
        foreach (GameObject currentEnemy in currentListEnemies)
        {
            syncContext.Post(_ => {
                Destroy(currentEnemy);
            }, null);
        }
    }

    public async Task deleteCurrentPlayer() {
        syncContext.Post(_ => {
            Destroy(viewModel.currentPlayer());
        }, null);
    }

    public async Task deleteCurrentSpawmPopulation()
    {
        syncContext.Post(_ => {
            GameObject current = viewModel.currentSpawmPopulation();
            Destroy(current);
        }, null);
    }
}
