using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LoadGameUIViewModelDelegate {
    void goToBack();
    void goToInteractionGame();
}
public interface LoadGameUIViewModel {
    LoadGameUIViewModelDelegate myDelegate { set; }
    string title { get; }
    string back { get; }
    string load { get; }

    void goBack();
    void loadGame();
}

public class LoadGameUIViewModelImpl : LoadGameUIViewModel
{

    private LoadGameUIViewModelDelegate _myDelegate;
    public LoadGameUIViewModelDelegate myDelegate { set => _myDelegate = value; }

    public string title => "Cargar Partida";

    public string back => "Volver";

    public string load => "Cargar";

    public void goBack()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToBack();
    }

    public void loadGame()
    {
        if (notExistsDelegate()) { return; }
        _myDelegate.goToInteractionGame();
    }

    // private methods
    private bool notExistsDelegate() => _myDelegate == null;
}
