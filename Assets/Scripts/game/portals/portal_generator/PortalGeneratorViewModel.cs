using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PortalGeneratorViewModelDelegate {
    void generatePortals(List<PortalModel> portalModels);
    void deleteAllPortals(List<GameObject> allPortals);
    void deleteAllEnemies(List<GameObject> allEnemies);
    void deleteAllMaterials(List<GameObject> allMaterials);
}

public interface PortalGeneratorViewModel {

    Level getCurrentLevel { get; }
    bool isGameChangedLevel { get; }
    PortalGeneratorViewModelDelegate myDelegate { get; set; }
    void loadPortals();
    void deletePortal(GameObject portal);
    void addPortal(GameObject portal);
    void changeLevel();
}

public class PortalGeneratorViewModelImpl : PortalGeneratorViewModel
{

    private readonly LevelGetCurrentLevelUseCase getCurrentLevelUseCase = new LevelGetCurrentLevelUseCaseImpl();
    private readonly PortalGetListPortalsByLevelUseCase getListPortalsByLevelUseCase = new PortalGetListPortalsByLevelUseCaseImpl();
    private readonly PortalGetAllListPortalsGameObjectUseCase getAllListPortalsGameObjectUseCase = new PortalGetAllListPortalsGameObjectUseCaseImpl();
    private readonly PortalDeleteAPortalUseCase deletePortalUseCase = new PortalDeleteAPortalUseCaseImpl();
    private readonly PortalAddAPortalUseCase addAPortalUseCase = new PortalAddAPortalUseCaseImpl();
    private readonly StatusGameIsGameChangedLevelUseCase isGameChangedLevelUseCase = new StatusGameIsGameChangedLevelUseCaseImpl();
    private readonly StatusGameUpdateStatusUseCase updateStatusUseCase = new StatusGameUpdateStatusUseCaseImpl();
    private readonly GetAllEnemiesUseCase getAllEnemiesUseCase = new GetAllEnemiesUseCaseImpl();
    private readonly PortalGetCurrentPortalPlayerUseCase getCurrentPortalPlayerUseCase = new PortalGetCurrentPortalPlayerUseCaseImpl();
    private readonly MaterialSpawmerGetAllMaterialsUseCase getAllMaterialsUseCase = new MaterialSpawmerGetAllMaterialsUseCaseImpl();

    private PortalGeneratorViewModelDelegate _myDelegate;

    public PortalGeneratorViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public Level getCurrentLevel => getCurrentLevelUseCase.invoke();

    public bool isGameChangedLevel => isGameChangedLevelUseCase.invoke();

    public void addPortal(GameObject portal) => addAPortalUseCase.invoke(portal: portal);

    public void changeLevel()
    {
        if (_myDelegate == null) return;
        _myDelegate.deleteAllEnemies(allEnemies: getAllEnemiesUseCase.invoke());
        _myDelegate.deleteAllMaterials(allMaterials: getAllMaterialsUseCase.invoke());
        var currentPortal = getCurrentPortalPlayerUseCase.invoke();
        if (currentPortal == null) return;
        updateStatusUseCase.invoke(statusGame: StatusGame.IN_GAME);
    }

    public void deletePortal(GameObject portal) => deletePortalUseCase.invoke(portal: portal);

    public void loadPortals()
    {
        if (_myDelegate == null) return;

        _myDelegate.deleteAllPortals(allPortals: getAllListPortalsGameObjectUseCase.invoke());
        _myDelegate.generatePortals(portalModels: getListPortalsByLevelUseCase.invoke());
    }

}