using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface NewGameUIDelegate : AbstractCanvasUIDelegate
{
    void createNewGame();

    void goToBack();

}

public class NewGameUI : AbstractCanvas, NewGameUIViewModelDelegate
{

    public TextMeshProUGUI back;
    public TextMeshProUGUI create;
    public TextMeshProUGUI gameCreated;
    public TMP_InputField namePlayer;
    public TextMeshProUGUI placeHolder;
    public TextMeshProUGUI title;

    public String currentNameGame;
    public bool iCanCreateNewGame = false;
    
    public NewGameUIDelegate myDelegate { set => _myDelegate = value; }
    private NewGameUIViewModel viewModel = new NewGameUIViewModelImpl();
    private NewGameUIDelegate _myDelegate;

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
        initElementsView();
    }
    private void Update()
    {
        updateTextGameLoaded();
        createNewGame();
    }

    //clicks
    public void clickCreateNewGame() {
        
        GameModel newGame = new GameModel();
        newGame.namePlayer = namePlayer.text;
        newGame.date = DateTime.Now;

        viewModel.createNewGame(newGame: newGame);
    }

    public void clickGoBack() {
        viewModel.goToBack();
    }


    //private methods
    private bool notExistsDelegate() {
        return _myDelegate == null;
    }

    private void initElementsView() {
        title.text = viewModel.title;
        back.text = viewModel.back;
        create.text = viewModel.create;
        placeHolder.text = viewModel.placeholder;
    }

    private void updateTextGameLoaded() {
        if (currentNameGame == null) return;
        gameCreated.text = currentNameGame;
    }

    private void createNewGame() {
        if (notExistsDelegate()) return;
        if (!iCanCreateNewGame) return;
        iCanCreateNewGame = false;
        _myDelegate.createNewGame();

    }

    //delegate

    public void createNewGame(string newGame)
    {
        if (notExistsDelegate()) { return; }
        currentNameGame = newGame;
        iCanCreateNewGame = true;
    }

    public void goToBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

}
