using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ConfigurationSpaceCraftUIViewModelDelegate {
    void goToLasers();
    void goToShields();
    void goToBack();
}

public interface ConfigurationSpaceCraftUIViewModel {
    ConfigurationSpaceCraftUIViewModelDelegate myDelegate { set; }
    string title { get; }
    string laser { get; }
    string shield { get; }
    string back { get; }

    void goToLasers();
    void goToShields();
    void goToBack();
}

public class ConfigurationSpaceCraftUIViewModelImpl : ConfigurationSpaceCraftUIViewModel
{
    private ConfigurationSpaceCraftUIViewModelDelegate _myDelegate;
    public ConfigurationSpaceCraftUIViewModelDelegate myDelegate { set => _myDelegate = value; }

    public string title => "Configuracion Nave";

    public string laser => "lasers";

    public string shield => "Escudos";

    public string back => "Volver";

    public void goToBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

    public void goToLasers()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToLasers();
    }

    public void goToShields()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToShields();
    }

    // private methods
    bool notExistsDelegate() => _myDelegate == null;
}
