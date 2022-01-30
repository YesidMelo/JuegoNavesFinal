using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalGetCurrentPortalGeneratorUseCase {
    GameObject invoke();
}

public class PortalGetCurrentPortalGeneratorUseCaseImpl : PortalGetCurrentPortalGeneratorUseCase
{
    private PortalRepository portalRepository = new PortalRepositoryImpl();
    public GameObject invoke() => portalRepository.getCurrentPortalGenerator();
}