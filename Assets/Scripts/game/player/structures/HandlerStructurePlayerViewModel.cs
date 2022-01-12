using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerStructurePlayerViewModelDelegate {
    void notifyLoadStructure();
}
public interface HandlerStructurePlayerViewModel {
    StructurePlayer currentStructure { get; }
    HandlerStructurePlayerViewModelDelegate myDelegate { get; set; }
    void updateStructure(StructurePlayer structurePlayer);
    void loadStructure();
    bool isGameInPause();
}
public class HandlerStructurePlayerViewModelImpl : HandlerStructurePlayerViewModel {

    private SpacecraftPlayerLoadStructureUseCase loadStructureUseCase = new SpacecraftPlayerLoadStructureUseCaseImpl();
    private SpacecraftPlayerUpdateStructureUseCase updateStructureUseCase = new SpacecraftPlayerUpdateStructureUseCaseImpl();
    private SpacecraftPlayerGetCurrentStructureUseCase getCurrentStructureUseCase = new SpacecraftPlayerGetCurrentStructureUseCaseImpl();
    private StatusGameIsGameInPauseUseCase isGameInPauseUseCase = new StatusGameIsGameInPauseUseCaseImpl();

    private HandlerStructurePlayerViewModelDelegate _myDelegate;

    public StructurePlayer currentStructure => getCurrentStructureUseCase.invoke();

    public HandlerStructurePlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public bool isGameInPause() => isGameInPauseUseCase.invoke();

    public void loadStructure()
    {
        if (!loadStructureUseCase.invoke()) return;
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadStructure();
    }

    public void updateStructure(StructurePlayer structurePlayer)
    {
        updateStructureUseCase.invoke(structurePlayer);
        loadStructure();
    }
}