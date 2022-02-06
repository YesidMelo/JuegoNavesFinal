using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LifeSupportPlayerUIViewModelDelegate { }

public interface LifeSupportPlayerUIViewModel {
    LifeSupportPlayerUIViewModelDelegate myDelegate { set; get; }
    LifeSupportPlayer getCurrentLifeSupport { get; }
}

public class LifeSupportPlayerUIViewModelImpl : LifeSupportPlayerUIViewModel
{
    private LifeSupportPlayerGetCurrentTypeUseCase getCurrentTypeUseCase = new LifeSupportPlayerGetCurrentTypeUseCaseImpl();


    private LifeSupportPlayerUIViewModelDelegate _myDelegate;

    public LifeSupportPlayerUIViewModelDelegate myDelegate { 
        get => _myDelegate; 
        set => _myDelegate = value; 
    }

    public LifeSupportPlayer getCurrentLifeSupport => getCurrentTypeUseCase.invoke();
}