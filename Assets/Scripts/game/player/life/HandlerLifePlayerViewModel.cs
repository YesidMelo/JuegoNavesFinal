using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLifePlayerViewModelDelegate {
    void notifyLoadLife();
}
public interface HandlerLifePlayerViewModel { 
    int maxLife { get; }
    int currentLife{ get; }
    StructurePlayer currentStructureLife { get; }
    HandlerLifePlayerViewModelDelegate myDelegate { get; set; }
    float percentage();
    void updateCurrentLife(int life);
    void loadLife();
    void setStructurePlayer(StructurePlayer structure);
}

public class HandlerLifePlayerViewModelImpl : HandlerLifePlayerViewModel
{
    private SpacecraftPlayerGetLifeUseCase getLifeUseCase = new SpacecraftPlayerGetLifeUseCaseImpl();
    private SpacecraftPlayerGetMaxLifeUseCase getMaxLifeUseCase = new SpacecraftPlayerGetMaxLifeUseCaseImpl();
    private SpacecraftPlayerLoadLifeUseCase loadLifeUseCase = new SpacecraftPlayerLoadLifeUseCaseImpl();
    private SpacecraftPlayerUpdateMaxLifeStructureUseCase updateMaxLifeStructureUseCase = new SpacecraftPlayerUpdateMaxLifeStructureUseCaseImpl();
    private SpacecraftPlayerGetStructureLifeUseCase getStructureLifeUseCase = new SpacecraftPlayerGetStructureLifeUseCaseImpl();
    private SpacecraftPlayerUpdateCurrentLifeUseCase updateCurrentLifeUseCase = new SpacecraftPlayerUpdateCurrentLifeUseCaseImpl();
    private HandlerLifePlayerViewModelDelegate _myDelegate;

    public int maxLife => (int)getMaxLifeUseCase.invoke();

    public int currentLife => (int)getLifeUseCase.invoke();
    

    public HandlerLifePlayerViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public StructurePlayer currentStructureLife => getStructureLifeUseCase.invoke();

    public void loadLife()
    {
        if (!loadLifeUseCase.invoke()) return;
        if (_myDelegate == null) return;
        _myDelegate.notifyLoadLife();
    }

    public void setStructurePlayer(StructurePlayer structure)
    {
        updateMaxLifeStructureUseCase.invoke(structure);
        loadLife();
    }

    public void updateCurrentLife(int life)
    {
        updateCurrentLifeUseCase.invoke(life);
        loadLife();
    }

    public float percentage() {
        return Constants.lifeBarPlayer * (((float)currentLife) / ((float) maxLife));
    }
}