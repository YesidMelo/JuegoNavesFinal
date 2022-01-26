using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalIsPlayerInPortalUseCase {
    bool invoke();
}

public class PortalIsPlayerInPortalUseCaseImpl : PortalIsPlayerInPortalUseCase
{
    private PortalRepository portalRepository = new PortalRepositoryImpl();

    public bool invoke() => portalRepository.playerInPortal();
}