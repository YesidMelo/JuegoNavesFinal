using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalGeneratorViewModelDelegate {
    void generatePortals(List<PortalModel> portalModels);
}

public interface PortalGeneratorViewModel {

    Level getCurrentLevel { get; }
    PortalGeneratorViewModelDelegate myDelegate { get; set; }
    void loadPortals();
}

public class PortalGeneratorViewModelImpl : PortalGeneratorViewModel
{

    private LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();
    private PortalGetListPortalsByLevelUseCase getListPortalsByLevelUseCase = new PortalGetListPortalsByLevelUseCaseImpl();

    private PortalGeneratorViewModelDelegate _myDelegate;

    public PortalGeneratorViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public Level getCurrentLevel => getCurrentLevelUseCase.invoke();

    public void loadPortals()
    {
        if (_myDelegate != null) return;
        _myDelegate.generatePortals(portalModels: getListPortalsByLevelUseCase.invoke());
    }
}