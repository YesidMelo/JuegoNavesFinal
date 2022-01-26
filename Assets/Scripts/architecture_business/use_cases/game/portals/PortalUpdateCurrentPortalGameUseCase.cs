using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalUpdateCurrentPortalGameUseCase {
    void invoke(PortalModel portalModel);
}

public class PortalUpdateCurrentPortalGameUseCaseImpl : PortalUpdateCurrentPortalGameUseCase
{
    private PortalRepository portalRepository = new PortalRepositoryImpl();

    public void invoke(PortalModel portalModel) => portalRepository.setCurrentPortal(portalModel: portalModel);
}