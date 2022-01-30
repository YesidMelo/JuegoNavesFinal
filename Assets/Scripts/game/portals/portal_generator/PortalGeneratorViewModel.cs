using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalGeneratorViewModelDelegate {
    void generatePortals(List<PortalModel> portalModels);
    void deleteAllPortals(List<GameObject> allPortals);
}

public interface PortalGeneratorViewModel {

    Level getCurrentLevel { get; }
    PortalGeneratorViewModelDelegate myDelegate { get; set; }
    void loadPortals();
    void deletePortal(GameObject portal);
    void addPortal(GameObject portal);
}

public class PortalGeneratorViewModelImpl : PortalGeneratorViewModel
{

    private LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();
    private PortalGetListPortalsByLevelUseCase getListPortalsByLevelUseCase = new PortalGetListPortalsByLevelUseCaseImpl();
    private PortalGetAllListPortalsGameObjectUseCase getAllListPortalsGameObjectUseCase = new PortalGetAllListPortalsGameObjectUseCaseImpl();
    private PortalDeleteAPortalUseCase deletePortalUseCase = new PortalDeleteAPortalUseCaseImpl();
    private PortalAddAPortalUseCase addAPortalUseCase = new PortalAddAPortalUseCaseImpl();

    private PortalGeneratorViewModelDelegate _myDelegate;

    public PortalGeneratorViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public Level getCurrentLevel => getCurrentLevelUseCase.invoke();

    public void addPortal(GameObject portal) => addAPortalUseCase.invoke(portal: portal);

    public void deletePortal(GameObject portal) => deletePortalUseCase.invoke(portal: portal);

    public void loadPortals()
    {
        if (_myDelegate == null) return;

        _myDelegate.deleteAllPortals(allPortals: getAllListPortalsGameObjectUseCase.invoke());
        _myDelegate.generatePortals(portalModels: getListPortalsByLevelUseCase.invoke());
    }

}