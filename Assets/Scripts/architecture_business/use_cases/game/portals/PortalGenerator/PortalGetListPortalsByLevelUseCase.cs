using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalGetListPortalsByLevelUseCase {
    List<PortalModel> invoke();
}

public class PortalGetListPortalsByLevelUseCaseImpl : PortalGetListPortalsByLevelUseCase
{
    private LevelRepository levelRepository = new LevelRepositoryImpl();
    private PortalRepository portalRepository = new PortalRepositoryImpl();

    public List<PortalModel> invoke() => portalRepository.getListPortalsByLevel(currentLevel: levelRepository.getCurrentLevel);
}