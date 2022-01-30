using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractionGameConfigLevelViewModelDelegate { }

public interface InteractionGameConfigLevelViewModel {
    InteractionGameConfigLevelViewModelDelegate myDelegate { set; }
    GameObject currentPlayer { get; }
    GameObject currentSpawmPopulation { get; }
    GameObject currentPortalGenerator { get; }
    void setCurrentPlayer(GameObject currentPlayer);
    void setCurrentSpawmPopulation(GameObject currentSpawmPopulation);
    void setCurrentPortalGenerator(GameObject portalGenerator);
}

public class InteractionGameConfigLevelViewModelImpl : InteractionGameConfigLevelViewModel
{
    private GetCurrentPlayerUseCase getCurrentPlayerUseCase = new GetCurrentPlayerUseCaseImpl();
    private SetCurrentPlayerUseCase setCurrentPlayerUseCase = new SetCurrentPlayerUseCaseImpl();
    private GetCurrentSpawmPopulationUseCase getCurrentSpawmPopulationUseCase = new GetCurrentSpawmPopulationUseCaseImpl();
    private SetCurrentSpawmPopulationUseCase setCurrentSpawmPopulationUseCase = new SetCurrentSpawmPopulationUseCaseImpl();
    private PortalSetCurrentPortalGeneratorUseCase setCurrentPortalGeneratorUseCase = new PortalSetCurrentPortalGeneratorUseCaseImpl();
    private PortalGetCurrentPortalGeneratorUseCase getCurrentPortalGeneratorUseCase = new PortalGetCurrentPortalGeneratorUseCaseImpl();


    private InteractionGameConfigLevelViewModelDelegate _myDelegate;

    public InteractionGameConfigLevelViewModelDelegate myDelegate { set { _myDelegate = value; } }

    public GameObject currentPlayer => getCurrentPlayerUseCase.invoke();

    public GameObject currentSpawmPopulation => getCurrentSpawmPopulationUseCase.invoke();

    public GameObject currentPortalGenerator => getCurrentPortalGeneratorUseCase.invoke();

    public void setCurrentPlayer(GameObject currentPlayer) => setCurrentPlayerUseCase.invoke(currentPlayer: currentPlayer);

    public void setCurrentPortalGenerator(GameObject portalGenerator) => setCurrentPortalGeneratorUseCase.invoke(portalGenerator: portalGenerator);

    public void setCurrentSpawmPopulation(GameObject currentSpawmPopulation) => setCurrentSpawmPopulationUseCase.invoke(spawmPopulation: currentSpawmPopulation);
}