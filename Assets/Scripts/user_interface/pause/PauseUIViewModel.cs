using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface PauseUIViewModelDelegate {
    void goContinue();
    void goSaveAndExit();
    Task deleteAllEnemies();
    Task deleteCurrentPlayer();
    Task deleteCurrentSpawmPopulation();
    Task deleteCurrentPortalGenerator();
    Task deleteCurrentPortals();
    Task deleteCurrentMaterials();
    Task deleteCurrentMaterialSpawmer();
}

public interface PauseUIViewModel {
    PauseUIViewModelDelegate myDelegate { set; }
    string title { get; }
    string continueText {get;}
    string saveAndExit { get; }

    void goContinue();
    void goSaveAndExit();

    List<GameObject> getAllElementToDelete();
    GameObject currentPlayer();
    GameObject currentSpawmPopulation();
    GameObject currentPortalGenerator();
    GameObject currentSpawmMaterial();
    List<GameObject> currentPortals();
    List<GameObject> currentAllMaterials();
}

public class PauseUIViewModelImpl : PauseUIViewModel
{

    private readonly CurrentLangajeUseCase currentLangajeUseCase = new CurrentLangajeUseCaseImpl();
    private readonly DeleteCurrentPlayerUseCase deleteCurrentPlayerUseCase = new DeleteCurrentPlayerUseCaseImpl();
    private readonly DeleteCurrentSpawmPopulationUseCase deleteCurrentSpawmPopulationUseCase = new DeleteCurrentSpawmPopulationUseCaseImpl();
    private readonly GetAllEnemiesUseCase getAllEnemiesUseCase = new GetAllEnemiesUseCaseImpl();
    private readonly GetCurrentPlayerUseCase currentPlayerUseCase = new GetCurrentPlayerUseCaseImpl();
    private readonly GetCurrentSpawmPopulationUseCase spawmPopulationUseCase = new GetCurrentSpawmPopulationUseCaseImpl();
    private readonly SaveGameUseCase saveGameUseCase = new SaveGameUseCaseImpl();
    private readonly StagePopulationClearCacheUseCase stagePopulationClearUseCase = new StagePopulationClearCacheUseCaseImpl();
    private readonly StatusGameUpdateStatusUseCase updateStatusUseCase = new StatusGameUpdateStatusUseCaseImpl();
    private readonly SaveGameClearCachesGameUseCase clearCachesGameUseCase = new SaveGameClearCachesGameUseCaseImpl();
    private readonly PortalGetCurrentPortalGeneratorUseCase getCurrentPortalGeneratorUseCase = new PortalGetCurrentPortalGeneratorUseCaseImpl();
    private readonly PortalGetAllListPortalsGameObjectUseCase getAllListPortalsGameObjectUseCase = new PortalGetAllListPortalsGameObjectUseCaseImpl();
    private readonly MaterialSpawmerGetAllMaterialsUseCase getAllMaterialsUseCase = new MaterialSpawmerGetAllMaterialsUseCaseImpl();
    private readonly MaterialSpawmerGetCurrentMaterialGeneratorUseCase getCurrentMaterialGeneratorUseCase = new MaterialSpawmerGetCurrentMaterialGeneratorUseCaseImpl();


    PauseUIViewModelDelegate _myDelegate;

    public PauseUIViewModelDelegate myDelegate { set => _myDelegate = value; }

    public string title => _currentLanguage.getNameTag(NameTagLanguage.PAUSE);

    public string continueText => _currentLanguage.getNameTag(NameTagLanguage.CONTINUE);

    public string saveAndExit => _currentLanguage.getNameTag(NameTagLanguage.SAVE_AND_EXIT);

    private AbstractLanguage _currentLanguage;

    public PauseUIViewModelImpl() {
        _currentLanguage = currentLangajeUseCase.invoke();
    }

    public void goContinue()
    {
        if (notExistsDelegate()) { return; }
        updateStatusUseCase.invoke(StatusGame.IN_GAME);
        _myDelegate.goContinue();
    }

    public void goSaveAndExit()
    {
        if (notExistsDelegate()) { return; }
        updateStatusUseCase.invoke(StatusGame.PAUSE);

        Task.Run(async () => {
            try
            {
                await _myDelegate.deleteAllEnemies();
                await saveGameUseCase.invoke();
                await _myDelegate.deleteCurrentPlayer();
                await _myDelegate.deleteCurrentSpawmPopulation();
                await _myDelegate.deleteCurrentPortalGenerator();
                await _myDelegate.deleteCurrentPortals();
                await _myDelegate.deleteCurrentMaterials();
                await _myDelegate.deleteCurrentMaterialSpawmer();
                await Task.Delay(100);
                await deleteCurrentPlayerUseCase.invoke();
                await deleteCurrentSpawmPopulationUseCase.invoke();
                await Task.Delay(100);
                await stagePopulationClearUseCase.invoke();
                updateStatusUseCase.invoke(StatusGame.MAIN_MENU);
                await clearCachesGameUseCase.invoke();
                _myDelegate.goSaveAndExit();
            }
            catch (Exception e) {
                Debug.Log(e.Message);
            }
        });
    }

    // private methods

    private bool notExistsDelegate() => _myDelegate == null;

    public List<GameObject> getAllElementToDelete() => getAllEnemiesUseCase.invoke();
    public GameObject currentPlayer() => currentPlayerUseCase.invoke();
    public GameObject currentSpawmPopulation() => spawmPopulationUseCase.invoke();

    public GameObject currentPortalGenerator() => getCurrentPortalGeneratorUseCase.invoke();

    public List<GameObject> currentPortals() => getAllListPortalsGameObjectUseCase.invoke();

    public List<GameObject> currentAllMaterials() => getAllMaterialsUseCase.invoke();

    public GameObject currentSpawmMaterial() => getCurrentMaterialGeneratorUseCase.invoke();
}
