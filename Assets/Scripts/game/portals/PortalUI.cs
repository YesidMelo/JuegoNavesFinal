using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PortalUI : MonoBehaviour, PortalUIViewModelDelegate
{
    //Disparador en hilo principal
    //documentacion en : https://stackoverflow.com/questions/41330771/use-unity-api-from-another-thread-or-call-a-function-in-the-main-thread
    //documentacion en : https://docs.microsoft.com/en-us/dotnet/api/system.threading.synchronizationcontext?view=net-5.0
    private SynchronizationContext syncContext;


    public Level currentLevel = Level.LEVEL1_SECTION1;
    public Level levelToChange = Level.LEVEL1_SECTION1;
    public bool updateLevel = false;

    private PortalUIViewModel _viewModel = new PortalUIViewModelImpl();

    void Start()
    {
        syncContext = SynchronizationContext.Current;
        _viewModel.myDelegate = this;
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = _viewModel.getCurrentLevel;
        updateLevelInUnity();
    }

    //public methods

    //private methods

    //ui unity methods
    private void updateLevelInUnity() {
        if (!updateLevel) return;
        if (levelToChange == currentLevel) return;
        updateLevel = false;
        _viewModel.changeLevel(level: levelToChange);
    }

    //delegate methods

    public async Task deleteAllEnemies()
    {
        List<GameObject> currentListEnemies = new List<GameObject>();

        foreach (GameObject current in _viewModel.getAllEnemies()) {
            currentListEnemies.Add(current);
        }

        foreach (GameObject currentEnemy in currentListEnemies) {
            
            if (syncContext == null) continue;
            syncContext.Post(_ => {
                Debug.Log($"Tienes un enemigo {currentEnemy.name}");
                if (currentEnemy.name.Contains(Constants.nameSpawmerPoblation)) return;
                Destroy(currentEnemy);
            }, null);
            await Task.Delay(Constants.timeAwaitDelete);
        }
    }
}
