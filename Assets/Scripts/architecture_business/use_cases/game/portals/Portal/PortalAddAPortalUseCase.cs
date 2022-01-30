using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalAddAPortalUseCase {
    void invoke(GameObject portal);
}

public class PortalAddAPortalUseCaseImpl : PortalAddAPortalUseCase
{
    private PortalRepository portalRepository = new PortalRepositoryImpl();

    public void invoke(GameObject portal) => portalRepository.addPortal(portal: portal);
}