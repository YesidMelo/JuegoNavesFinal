using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalRepository {
    bool playerInPortal();
    void setCurrentPortal(PortalModel portalModel);
    PortalModel getCurrentPortal();
    List<PortalModel> getListPortalsByLevel(Level currentLevel);
}

public class PortalRepositoryImpl: PortalRepository {

    private PortalDatasourceCache cache = PortalDatasourceCacheImpl.getInstance();

    public PortalModel getCurrentPortal() => cache.getCurrentPortal();

    public List<PortalModel> getListPortalsByLevel(Level currentLevel) => cache.getListPortalsByLevel(currentLevel: currentLevel);

    public bool playerInPortal() => cache.playerInPortal();

    public void setCurrentPortal(PortalModel portalModel) => cache.setCurrentPortal(portalModel: portalModel);
}