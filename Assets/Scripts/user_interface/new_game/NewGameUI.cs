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

    public TextMeshProUGUI title;
    public TextMeshProUGUI back;
    public TextMeshProUGUI create;
    
    public NewGameUIDelegate myDelegate { set => _myDelegate = value; }
    private NewGameUIViewModel viewModel = new NewGameUIViewModelImpl();
    private NewGameUIDelegate _myDelegate;

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
        initElementsView();
    }

    //clicks
    public void clickCreateNewGame() {
        viewModel.createNewGame("nuevo juego");
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
    }

    //delegate

    public void createNewGame(string name)
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.createNewGame();
    }

    public void goToBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

}
