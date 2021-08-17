using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface ConfigurationGameUIDelegate : AbstractCanvasUIDelegate
{
    void goToBack();
}

public class ConfigurationGameUI : AbstractCanvas, ConfigurationGameUIViewModelDelegate
{

    public ConfigurationGameUIDelegate myDelegate { set { _myDelegate = value; } }
    public TextMeshProUGUI title;
    public TextMeshProUGUI back;
    public TextMeshProUGUI save;
    

    private ConfigurationGameUIViewModel viewModel = new ConfigurationGameUIViewModelImpl();
    private ConfigurationGameUIDelegate _myDelegate;

    // Start is called before the first frame update
    void Start()
    {
        initValuesUI();
        viewModel.myDelegate = this;
    }

    // clicks
    public void onClickBack() {
        viewModel.goBack();
    }

    public void onClickSave() {
        viewModel.saveConfiguration();
    }

    // private methods
    void initValuesUI() {
        title.text = viewModel.title;
        back.text = viewModel.back;
        save.text = viewModel.save;
    }

    // delegate
    public void goToBack()
    {
        if (_myDelegate == null) { return; }
        _myDelegate.goToBack();
    }
}
