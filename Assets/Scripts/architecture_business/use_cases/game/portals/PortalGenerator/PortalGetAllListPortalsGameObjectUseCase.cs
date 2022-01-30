using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalGetAllListPortalsGameObjectUseCase {
    List<GameObject> invoke();
}

public class PortalGetAllListPortalsGameObjectUseCaseImpl : PortalGetAllListPortalsGameObjectUseCase
{
    private PortalRepository portalRepository = new PortalRepositoryImpl();
    public List<GameObject> invoke() => portalRepository.getAllPortalsGameObject();
}