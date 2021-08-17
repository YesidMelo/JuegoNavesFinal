using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface NewGameUIViewModelDelegate {
    void createNewGame(string name);
    void goToBack();

}

public interface NewGameUIViewModel {
    string title { get; }
    string back { get; }
    string create { get; }
    NewGameUIViewModelDelegate myDelegate { set; }

    void createNewGame(string name);
    void goToBack();
}

public class NewGameUIViewModelImpl : NewGameUIViewModel
{
    private NewGameUIViewModelDelegate _myDelegate;


    //set and gets
    public NewGameUIViewModelDelegate myDelegate { set => _myDelegate = value; }

    public string title => "Nueva partida";

    public string back => "Volver";

    public string create => "Crear partida";

    // public methods

    public void createNewGame(string name)
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.createNewGame(name);
    }

    public void goToBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

    // private methods
    private bool notExistsDelegate() {
        return _myDelegate == null;
    }
}
