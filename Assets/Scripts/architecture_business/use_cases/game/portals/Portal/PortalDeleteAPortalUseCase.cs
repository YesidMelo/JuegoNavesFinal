using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalDeleteAPortalUseCase {
    void invoke(GameObject portal);
}

public class PortalDeleteAPortalUseCaseImpl : PortalDeleteAPortalUseCase
{
    private PortalRepository portalRepository = new PortalRepositoryImpl();

    public void invoke(GameObject portal) => portalRepository.deletePortal(portal: portal);
}