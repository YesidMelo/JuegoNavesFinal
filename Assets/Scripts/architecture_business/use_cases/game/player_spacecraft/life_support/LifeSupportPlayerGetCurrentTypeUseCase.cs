using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LifeSupportPlayerGetCurrentTypeUseCase {
    LifeSupportPlayer invoke();
}

public class LifeSupportPlayerGetCurrentTypeUseCaseImpl : LifeSupportPlayerGetCurrentTypeUseCase
{
    private readonly SpacecraftPlayerLifeSupportRepository lifeSupportRepository = new SpacecraftPlayerLifeSupportRepositoryImpl();

    public LifeSupportPlayer invoke() => lifeSupportRepository.getCurrentLifeSupport();
}