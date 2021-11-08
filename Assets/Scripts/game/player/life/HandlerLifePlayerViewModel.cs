using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HandlerLifePlayerViewModelDelegate {
    void notifyLoadLife();
}
public interface HandlerLifePlayerViewModel { 
    float maxLife { get; }
    float currentLife{ get; }
    StructurePlayer currentStructureLife { get; }
    HandlerLifePlayerViewModelDelegate myDelegate { get; set; }
    float percentage();
    void updateCurrentLife(float life);
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

    public float maxLife => getMaxLifeUseCase.invoke();

    public float currentLife => getLifeUseCase.invoke();
    

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

    public void updateCurrentLife(float life)
    {
        updateCurrentLifeUseCase.invoke(life);
        loadLife();
    }

    public float percentage() {
        return Constants.lifeBarPlayer * (currentLife / maxLife);
    }
}