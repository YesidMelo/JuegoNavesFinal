using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LaserOptionsUIViewModelDelegate {
    void goBack();
}

public interface LaserOptionsUIViewModel {
    LaserOptionsUIViewModelDelegate myDelegate { set; }
    string title { get; }
    string labelCurrentLaser { get; }
    string descriptionCurrentLaser { get; }
    string back { get; }
    string save { get; }

    void goBack();
    void saveConfiguration();

}

public class LaserOptionsUIViewModelImpl : LaserOptionsUIViewModel
{

    private LaserOptionsUIViewModelDelegate _myDelegate;

    public string title => "Lasers";

    public string labelCurrentLaser => "Laser actual";

    public string descriptionCurrentLaser => "Tipo 1";

    public string back => "Volver";

    public string save => "Guardar";

    public LaserOptionsUIViewModelDelegate myDelegate { set => _myDelegate = value; }

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

    //private methods
    bool notExistsDelegate() => _myDelegate == null;
}
