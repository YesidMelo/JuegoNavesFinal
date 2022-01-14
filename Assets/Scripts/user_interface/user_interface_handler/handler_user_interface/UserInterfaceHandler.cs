using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UserInterfaceHandler : MonoBehaviour, UserInterfaceHandlerViewModelDelegate
{
    public CanvasAvailable currentCanvasEnum = CanvasAvailable.SPLASH;

    public Canvas about;
    public Canvas ConfigurationGame;
    public Canvas ConfigurationSpacecraft;
    public Canvas GameOver;
    public Canvas interactionGame;
    public Canvas laserOptions;
    public Canvas loadGame;
    public Canvas loading;
    public Canvas MainMenu;
    public Canvas newGame;
    public Canvas pause;
    public Canvas ShieldOptions;
    public Canvas splash;

    public Camera mainCamera;
    private Canvas currentCanvasPrefab;

    [Inject] public UserInterfaceHandlerViewModel viewModel;
    [Inject] public DiContainer container;

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
        currentCanvasEnum = viewModel.currentCanvas;
        viewModel.checkCurrentCanvas();
        viewModel.setCurrentMainCamera(mainCamera: mainCamera);
    }

    private void Update()
    {
        
    }

    // private methods

    private void startPrefabGameobject(Canvas prefab) {
        if (currentCanvasPrefab != null) {
            Destroy(currentCanvasPrefab.gameObject);
        }
        currentCanvasPrefab = Instantiate(prefab);
        currentCanvasPrefab.transform.parent = transform;
    }

    // delegate
    public void goToSplash(SplashUIDelegate splashUIDelegate)
    {
        startPrefabGameobject(splash);
        SplashUI currentSplash = currentCanvasPrefab.GetComponent<SplashUI>();
        currentSplash.myDelegate = splashUIDelegate;
    }

    public void goToMainMenu(MainMenuUIDelegate mainMenuUIDelegate)
    {
        startPrefabGameobject(MainMenu);
        MainMenuUI mainMenuUI = currentCanvasPrefab.GetComponent<MainMenuUI>();
        mainMenuUI.myDelegate = mainMenuUIDelegate;
    }

    public void goToAbout(AboutUIDelegate aboutUIDelegate)
    {
        startPrefabGameobject(about);
        AboutUI aboutUI = currentCanvasPrefab.GetComponent<AboutUI>();
        aboutUI.myDelegate = aboutUIDelegate;
    }

    public void goToNewGame(NewGameUIDelegate newGameUIDelegate)
    {
        startPrefabGameobject(newGame);
        NewGameUI newGameUI = currentCanvasPrefab.GetComponent<NewGameUI>();
        newGameUI.myDelegate = newGameUIDelegate;
    }

    public void goToInteractionGame(InteractionGameUIDelegate interactionGameUIDelegate)
    {
        startPrefabGameobject(interactionGame);
        InteractionGameUI interactionGameUI = currentCanvasPrefab.GetComponent<InteractionGameUI>();
        interactionGameUI.myDelegate = interactionGameUIDelegate;
    }

    public void goToConfigurationGame(ConfigurationGameUIDelegate configurationGameUIDelegate)
    {
        startPrefabGameobject(ConfigurationGame);
        ConfigurationGameUI configurationGameUI = currentCanvasPrefab.GetComponent<ConfigurationGameUI>();
        configurationGameUI.myDelegate = configurationGameUIDelegate;
    }

    public void showProgress() => startPrefabGameobject(loading);


    public void goToPause(PauseUIDelegate pauseUIDelegate)
    {
        startPrefabGameobject(pause);
        PauseUI pauseUI = currentCanvasPrefab.GetComponent<PauseUI>();
        pauseUI.myDelegate = pauseUIDelegate;
    }

    public void goToConfigurationSpacecraft(ConfigurationSpaceCraftUIDelegate spaceCraftUIDelegate)
    {
        startPrefabGameobject(ConfigurationSpacecraft);
        ConfigurationSpaceCraftUI configurationSpaceCraftUI = currentCanvasPrefab.GetComponent<ConfigurationSpaceCraftUI>();
        configurationSpaceCraftUI.myDelegate = spaceCraftUIDelegate;
    }

    public void goToLaserOptions(LaserOptionsUIDelegate laserOptionsUIDelegate)
    {
        startPrefabGameobject(laserOptions);
        LaserOptionsUI laserOptionsUI = currentCanvasPrefab.GetComponent<LaserOptionsUI>();
        laserOptionsUI.myDelegate = laserOptionsUIDelegate;
    }

    public void goToShieldOption(ShieldOptionsUIDelegate shieldOptionsUIDelegate)
    {
        startPrefabGameobject(ShieldOptions);
        ShieldOptionsUI shieldOptionsUI = currentCanvasPrefab.GetComponent<ShieldOptionsUI>();
        shieldOptionsUI.myDelegate = shieldOptionsUIDelegate;
    }

    public void goToLoadGame(LoadGameUIDelegate loadGameUIDelegate)
    {
        startPrefabGameobject(loadGame);
        LoadGameUI loadGameUI = currentCanvasPrefab.GetComponent<LoadGameUI>();
        loadGameUI.myDelegate = loadGameUIDelegate;
    }

    public void goToGameOver(GameOverUIDelegate gameOverUIDelegate) {
        startPrefabGameobject(GameOver);
        GameOverUI gameOverUI = currentCanvasPrefab.GetComponent<GameOverUI>();
        gameOverUI.myDelegate = gameOverUIDelegate;
    }
}

