using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalGetCurrentPortalUseCase {
    PortalModel invoke();
}

public class PortalGetCurrentPortalUseCaseImpl : PortalGetCurrentPortalUseCase
{

    private PortalRepository repository = new PortalRepositoryImpl();

    public PortalModel invoke() => repository.getCurrentPortal();
}