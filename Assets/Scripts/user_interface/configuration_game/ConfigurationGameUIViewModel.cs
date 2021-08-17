using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ConfigurationGameUIViewModelDelegate {
    void goToBack();
}

public interface ConfigurationGameUIViewModel {
    ConfigurationGameUIViewModelDelegate myDelegate { set; }
    string title { get; }
    string back { get; }
    string save { get; }

    void goBack();
    void saveConfiguration();
}

public class ConfigurationGameUIViewModelImpl : ConfigurationGameUIViewModel
{

    private ConfigurationGameUIViewModelDelegate _myDelegate;

    public ConfigurationGameUIViewModelDelegate myDelegate { set => _myDelegate = value; }

    public string title => "Configuracion juego";

    public string back => "Volver";

    public string save => "Guardar";

    public void goBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

    public void saveConfiguration() {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

    // private methods
    bool notExistsDelegate() => _myDelegate == null;

}
