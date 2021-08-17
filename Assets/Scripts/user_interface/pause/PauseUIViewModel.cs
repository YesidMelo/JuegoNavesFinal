using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PauseUIViewModelDelegate {
    void goContinue();
    void goSaveAndExit();
}

public interface PauseUIViewModel {
    PauseUIViewModelDelegate myDelegate { set; }
    string title { get; }
    string continueText {get;}
    string saveAndExit { get; }

    void goContinue();
    void goSaveAndExit();
}

public class PauseUIViewModelImpl : PauseUIViewModel
{

    PauseUIViewModelDelegate _myDelegate;

    public PauseUIViewModelDelegate myDelegate { set => _myDelegate = value; }

    public string title => "Pausa";

    public string continueText => "Continuar";

    public string saveAndExit => "Guardar y SALIR";

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

    // private methods

    private bool notExistsDelegate() => _myDelegate == null;
}
