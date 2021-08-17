using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShiledOptionsUIViemodelDelegate {
    void goBack();
}

public interface ShiledOptionsUIViemodel {
    ShiledOptionsUIViemodelDelegate myDelegate { set; }
    string back { get; }
    string currentShield { get; }
    string labelCurrentShield { get; }
    string save { get; }
    string title { get; }

    void saveConfiguration();
    void goBack();
}

public class ShiledOptionsUIViemodelImpl : ShiledOptionsUIViemodel
{
    private ShiledOptionsUIViemodelDelegate _myDelegate;
    public ShiledOptionsUIViemodelDelegate myDelegate { set => _myDelegate = value; }

    public string back => "Volver";

    public string currentShield => "Escudo 1";

    public string labelCurrentShield => "Escudo actual";

    public string save => "Guardar";

    public string title => "Escudo";

    public void goBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goBack();
    }

    public void saveConfiguration()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goBack();

    }
    // private methods
    bool notExistsDelegate() => _myDelegate == null;
}
