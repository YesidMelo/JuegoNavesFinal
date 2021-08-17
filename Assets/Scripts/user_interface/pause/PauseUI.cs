using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface PauseUIDelegate : AbstractCanvasUIDelegate {
    void goContinue();
    void goSaveAndExit();
}

public class PauseUI : AbstractCanvas, PauseUIViewModelDelegate
{


    public PauseUIDelegate myDelegate { set { _myDelegate = value; } }
    public TextMeshProUGUI title;
    public TextMeshProUGUI continueText;
    public TextMeshProUGUI saveAndExit;

    private PauseUIViewModel viewModel = new PauseUIViewModelImpl();
    private PauseUIDelegate _myDelegate;

    // Start is called before the first frame update
    void Start()
    {
        viewModel.myDelegate = this;
        initValues();
    }

    // clicks
    public void onClickContinue()
    {
        viewModel.goContinue();
    }

    public void onClickSaveAndExit() {
        viewModel.goSaveAndExit();
    }

    // private methods
    bool notExistsDelegate() => _myDelegate == null;

    void initValues() {
        title.text = viewModel.title;
        continueText.text = viewModel.continueText;
        saveAndExit.text = viewModel.saveAndExit;
    }

    // delegate

    public void goContinue()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goContinue();
    }

    public void goSaveAndExit()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goSaveAndExit();
    }

}
