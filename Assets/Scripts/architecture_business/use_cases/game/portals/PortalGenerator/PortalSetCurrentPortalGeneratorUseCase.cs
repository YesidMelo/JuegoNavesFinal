using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalSetCurrentPortalGeneratorUseCase {
    void invoke(GameObject portalGenerator);
}

public class PortalSetCurrentPortalGeneratorUseCaseImpl : PortalSetCurrentPortalGeneratorUseCase
{
    private PortalRepository portalRepository = new PortalRepositoryImpl();

    public void invoke(GameObject portalGenerator) => portalRepository.setCurrentPortalGenerator(portalGenerator: portalGenerator);
}