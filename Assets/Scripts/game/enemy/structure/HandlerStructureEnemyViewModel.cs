using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerStructureEnemyViewModelDelegate {
    void notifyLoadSpacecraft();
    void notifyLoadScructure();
}

public interface HandlerStructureEnemyViewModel {
    SpacecraftEnemy currentSpacecraft { get; }
    StructureEnemy currentStructure { get; }
    HandlerStructureEnemyViewModelDelegate myDelegate { get; set; }
    void loadSpacecraft(IdentificatorModel identificator);
    void deleteStructure(IdentificatorModel identificator);
}
public class HandlerStructureEnemyViewModelImpl : HandlerStructureEnemyViewModel
{
    private SpacecraftEnemyGetCurrentSpacecraftUseCase getCurrentSpacecraftUseCase = new SpacecraftEnemyGetCurrentSpacecraftUseCaseImpl();
    private StructureEnemyLoadStructureUseCase loadStructureUseCase = new StructureEnemyLoadStructureUseCaseImpl();
    private StructureEnemyGetCurrentStructureUseCase getCurrentStructureUseCase = new StructureEnemyGetCurrentStructureUseCaseImpl();
    private StructureEnemyDeleteStructureUseCase deleteStructureUseCase = new StructureEnemyDeleteStructureUseCaseImpl();

    private SpacecraftEnemy _currentSpacecraft;
    private StructureEnemy _currentStructure;
    private HandlerStructureEnemyViewModelDelegate _myDelegate;

    public SpacecraftEnemy currentSpacecraft => _currentSpacecraft;

    public HandlerStructureEnemyViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public StructureEnemy currentStructure => _currentStructure;

    public void deleteStructure(IdentificatorModel identificator) => deleteStructureUseCase.invoke(identificator);

    public void loadSpacecraft(IdentificatorModel identificator)
    {
        _currentSpacecraft = getCurrentSpacecraftUseCase.invoke(identificator);
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadSpacecraft();
        loadStructure(identificator);
    }

    //private methods
    private void loadStructure(IdentificatorModel identificator) {
        
        loadStructureUseCase.invoke(identificator);
        _currentStructure = getCurrentStructureUseCase.invoke(identificator);
        _myDelegate.notifyLoadScructure();
    }
}