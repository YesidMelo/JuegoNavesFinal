using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalAddPlayerInPortalUseCase {
    void invoke(PortalModel currentPortal);
}

public class PortalAddPlayerInPortalUseCaseImpl : PortalAddPlayerInPortalUseCase
{
    private PortalRepository portalRepository = new PortalRepositoryImpl();

    public void invoke(PortalModel currentPortal) => portalRepository.setCurrenPortalPlayer(currentPortal: currentPortal);
}