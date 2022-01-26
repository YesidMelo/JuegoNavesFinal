using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalDatasourceCache {
    bool playerInPortal();
    void setCurrentPortal(PortalModel portalModel);
    PortalModel getCurrentPortal();

    List<PortalModel> getListPortalsByLevel(Level currentLevel);
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

    
    private bool _playerInPortal = false;
    private PortalModel _currentPortal;
    private List<PortalModel> listPortals = new List<PortalModel>();

    private PortalDatasourceCacheImpl() {
        initListPortals();
    }

    public bool playerInPortal() => _playerInPortal;

    public void setCurrentPortal(PortalModel portalModel)
    {
        _playerInPortal = portalModel != null;
        _currentPortal = portalModel;
    }

    public PortalModel getCurrentPortal() => _currentPortal;

    public List<PortalModel> getListPortalsByLevel(Level currentLevel)
    {
        List<PortalModel> portalFiltered = HelpersList.filter(
            currentList: listPortals,
            myCondition: (PortalModel currentPortal) => {
            return _currentPortal.levelOrigin == currentLevel;
            }
        );
        return listPortals;
    }

    private void initListPortals() {
        listPortals.Add(new PortalModel(levelOrigin: Level.LEVEL1_SECTION1, levelDestination: Level.LEVEL1_SECTION2, positionX: 100f, positionY: 100f));
        listPortals.Add(new PortalModel(levelOrigin: Level.LEVEL1_SECTION2, levelDestination: Level.LEVEL1_SECTION1, positionX: 100f, positionY: 100f));
    }

}
