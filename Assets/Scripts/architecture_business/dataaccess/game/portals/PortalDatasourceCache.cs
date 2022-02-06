using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalDatasourceCache {
    
    List<PortalModel> getListPortalsByLevel(Level currentLevel);
    void setCurrentPortalGenerator(GameObject portalGenerator);
    void setCurrenPortalPlayer(PortalModel currentPortalPlayer);
    void deletePortal(GameObject portal);
    void addPortal(GameObject portal);
    GameObject getCurrentPortalGenerator();
    List<GameObject> getAllPortalsGameObject();
    bool isPlayerInPortal();
    PortalModel getCurrentPortal();
    void clearCache();
}

public class PortalDatasourceCacheImpl: PortalDatasourceCache
{
    ///static variables
    private static PortalDatasourceCache instance;

    //static methods
    public static PortalDatasourceCache getInstance() {
        if (instance == null) {
            instance = new PortalDatasourceCacheImpl();
        }
        return instance;
    }

    public static void destroyInstance() => instance = null;

    private List<PortalModel> _listPortals = new List<PortalModel>();
    private GameObject _currentPortalGenerator;
    private List<GameObject> _listPortalsGameObject = new List<GameObject>();
    private PortalModel _currentPortalPlayer;
    private bool _playerInPortal = false;

    private PortalDatasourceCacheImpl() {
        initListPortals();
    }

    public List<PortalModel> getListPortalsByLevel(Level currentLevel)
    {
        List<PortalModel> portalFiltered = HelpersList.filter(
            currentList: _listPortals,
            myCondition: (PortalModel currentPortal) => {
            return currentPortal.levelOrigin == currentLevel;
            }
        );
        return portalFiltered;
    }

    public void setCurrentPortalGenerator(GameObject portalGenerator) => _currentPortalGenerator = portalGenerator;

    public GameObject getCurrentPortalGenerator() => _currentPortalGenerator;


    public List<GameObject> getAllPortalsGameObject() => _listPortalsGameObject;

    public void deletePortal(GameObject portal)
    {
        if (!_listPortalsGameObject.Contains(portal)) return;
        _listPortalsGameObject.Remove(portal);
    }

    public void addPortal(GameObject portal)
    {
        if (_listPortalsGameObject.Contains(portal)) return;
        _listPortalsGameObject.Add(portal);
    }

    public void setCurrenPortalPlayer(PortalModel currentPortalPlayer)
    {
        _currentPortalPlayer = currentPortalPlayer;
        _playerInPortal = currentPortalPlayer != null;
    }

    public bool isPlayerInPortal() => _playerInPortal;
    public PortalModel getCurrentPortal() => _currentPortalPlayer;

    //private methods
    private void initListPortals() {
        _listPortals.Add(new PortalModel(levelOrigin: Level.LEVEL1_SECTION1, levelDestination: Level.LEVEL1_SECTION2, positionX: 100f, positionY: 100f));
        _listPortals.Add(new PortalModel(levelOrigin: Level.LEVEL1_SECTION2, levelDestination: Level.LEVEL1_SECTION1, positionX: 100f, positionY: 100f));
    }

    public void clearCache()
    {
        _listPortals.Clear();
        _currentPortalGenerator = null;
        _currentPortalPlayer = null;
        _playerInPortal = false;
        _listPortalsGameObject.Clear();
    }
}
