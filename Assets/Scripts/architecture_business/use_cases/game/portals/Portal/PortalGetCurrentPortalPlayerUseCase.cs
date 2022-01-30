using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalGetCurrentPortalPlayerUseCase {
    PortalModel invoke();
}

public class PortalGetCurrentPortalPlayerUseCaseImpl : PortalGetCurrentPortalPlayerUseCase
{
    PortalRepository portalRepository = new PortalRepositoryImpl();

    public PortalModel invoke() => portalRepository.getCurrentPortal();
}