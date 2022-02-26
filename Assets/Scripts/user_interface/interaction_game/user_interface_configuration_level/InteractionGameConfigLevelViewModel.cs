using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionGameConfigLevelViewModelDelegate { }

public interface InteractionGameConfigLevelViewModel {
    InteractionGameConfigLevelViewModelDelegate myDelegate { set; }
    GameObject currentPlayer { get; }
    GameObject currentSpawmPopulation { get; }
    GameObject currentPortalGenerator { get; }
    GameObject currentMaterialGenerator { get; }

    //GameObject currentSpawmerMaterial { get; }

    void setCurrentPlayer(GameObject currentPlayer);
    void setCurrentSpawmPopulation(GameObject currentSpawmPopulation);
    void setCurrentPortalGenerator(GameObject portalGenerator);
    void setCurrentMaterialGenerator(GameObject materialGenerator);
}

public class InteractionGameConfigLevelViewModelImpl : InteractionGameConfigLevelViewModel
{
    private readonly GetCurrentPlayerUseCase getCurrentPlayerUseCase = new GetCurrentPlayerUseCaseImpl();
    private readonly SetCurrentPlayerUseCase setCurrentPlayerUseCase = new SetCurrentPlayerUseCaseImpl();
    private readonly GetCurrentSpawmPopulationUseCase getCurrentSpawmPopulationUseCase = new GetCurrentSpawmPopulationUseCaseImpl();
    private readonly SetCurrentSpawmPopulationUseCase setCurrentSpawmPopulationUseCase = new SetCurrentSpawmPopulationUseCaseImpl();
    private readonly PortalSetCurrentPortalGeneratorUseCase setCurrentPortalGeneratorUseCase = new PortalSetCurrentPortalGeneratorUseCaseImpl();
    private readonly PortalGetCurrentPortalGeneratorUseCase getCurrentPortalGeneratorUseCase = new PortalGetCurrentPortalGeneratorUseCaseImpl();
    private readonly MaterialSpawmerGetCurrentMaterialGeneratorUseCase getCurrentMaterialGeneratorUseCase = new MaterialSpawmerGetCurrentMaterialGeneratorUseCaseImpl();
    private readonly MaterialSpawmerSetCurrentMaterialGeneratorUseCase setCurrentMaterialGeneratorUseCase = new MaterialSpawmerSetCurrentMaterialGeneratorUseCaseImpl();


    private InteractionGameConfigLevelViewModelDelegate _myDelegate;

    public InteractionGameConfigLevelViewModelDelegate myDelegate { set { _myDelegate = value; } }

    public GameObject currentPlayer => getCurrentPlayerUseCase.invoke();

    public GameObject currentSpawmPopulation => getCurrentSpawmPopulationUseCase.invoke();

    public GameObject currentPortalGenerator => getCurrentPortalGeneratorUseCase.invoke();

    public GameObject currentMaterialGenerator => getCurrentMaterialGeneratorUseCase.invoke();

    public void setCurrentMaterialGenerator(GameObject materialGenerator) => setCurrentMaterialGeneratorUseCase.invoke(materialSpawmer: materialGenerator);

    public void setCurrentPlayer(GameObject currentPlayer) => setCurrentPlayerUseCase.invoke(currentPlayer: currentPlayer);

    public void setCurrentPortalGenerator(GameObject portalGenerator) => setCurrentPortalGeneratorUseCase.invoke(portalGenerator: portalGenerator);

    public void setCurrentSpawmPopulation(GameObject currentSpawmPopulation) => setCurrentSpawmPopulationUseCase.invoke(spawmPopulation: currentSpawmPopulation);

}