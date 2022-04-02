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
    public bool playerInPortal = false;

    public PortalModel currentPortal;
    private PortalUIViewModel _viewModel = new PortalUIViewModelImpl();

    void Start()
    {
        syncContext = SynchronizationContext.Current;
        _viewModel.myDelegate = this;
    }

    void Update()
    {
        currentLevel = _viewModel.getCurrentLevel;
        playerInPortal = _viewModel.playerInPortal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isAPlayer(collision: collision)) return;
        _viewModel.setCurrentPortal(portalModel: currentPortal);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isAPlayer(collision: collision)) return;
        _viewModel.setCurrentPortal(portalModel: null);
    }

    //public methods

    //private methods

    //ui unity methods
   
    //delegate methods

    public async Task deleteAllEnemies()
    {
        List<GameObject> currentListEnemies = new List<GameObject>();

        foreach (GameObject current in _viewModel.getAllEnemies()) {
            currentListEnemies.Add(current);
        }

        Debug.Log($" materiales actuales {currentListEnemies.Count}");

        foreach (GameObject currentEnemy in currentListEnemies) {
            
            if (syncContext == null) continue;
            syncContext.Post(_ => { 
                if (currentEnemy.name.Contains(Constants.nameSpawmerPoblation)) return;
                Destroy(currentEnemy);
            }, null);
            await Task.Delay(Constants.timeAwaitDelete);
        }
    }

    private bool isAPlayer(Collider2D collision) {
        return collision.gameObject.name.Contains(Constants.nameShieldPlayer);
    }
}
