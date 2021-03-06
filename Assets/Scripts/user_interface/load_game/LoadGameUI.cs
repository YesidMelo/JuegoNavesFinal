using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface LoadGameUIDelegate : AbstractCanvasUIDelegate
{
    void goToBack();
    void goToInteractionGame();
}

public class LoadGameUI : AbstractCanvas, LoadGameUIViewModelDelegate
{
    public LoadGameUIDelegate myDelegate { set { _myDelegate = value; } }
    public TextMeshProUGUI title;
    public TextMeshProUGUI back;
    public TextMeshProUGUI load;

    private LoadGameUIViewModel viewModel = new LoadGameUIViewModelImpl();
    private LoadGameUIDelegate _myDelegate;


    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
        initElements();
    }

    //clicks
    public void clickBack() => viewModel.goBack();

    public void clickLoad() => viewModel.loadGame();

    // public methods
    // private Methods
    private void initElements() {
        title.text = viewModel.title;
        back.text = viewModel.back;
        load.text = viewModel.load;
    }

    private bool notExistsDelegate() => _myDelegate == null;


    // delegate 
    public void goToBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

    public void goToInteractionGame()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToInteractionGame();
    }
}
