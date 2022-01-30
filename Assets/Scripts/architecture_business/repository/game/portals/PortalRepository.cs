using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalRepository {

    List<PortalModel> getListPortalsByLevel(Level currentLevel);
    void setCurrentPortalGenerator(GameObject portalGenerator);
    void deletePortal(GameObject portal);
    void addPortal(GameObject portal);
    GameObject getCurrentPortalGenerator();
    List<GameObject> getAllPortalsGameObject();
}

public class PortalRepositoryImpl: PortalRepository {

    private PortalDatasourceCache cache = PortalDatasourceCacheImpl.getInstance();

    public List<PortalModel> getListPortalsByLevel(Level currentLevel) => cache.getListPortalsByLevel(currentLevel: currentLevel);

    public void setCurrentPortalGenerator(GameObject portalGenerator) => cache.setCurrentPortalGenerator(portalGenerator: portalGenerator);
    public GameObject getCurrentPortalGenerator() => cache.getCurrentPortalGenerator();

    public List<GameObject> getAllPortalsGameObject() => cache.getAllPortalsGameObject();

    public void deletePortal(GameObject portal) => cache.deletePortal(portal: portal);

    public void addPortal(GameObject portal) => cache.addPortal(portal: portal);
}