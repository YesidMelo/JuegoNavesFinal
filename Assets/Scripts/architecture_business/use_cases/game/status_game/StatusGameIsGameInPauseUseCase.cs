using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatusGameIsGameInPauseUseCase {
    bool invoke();
}

public class StatusGameIsGameInPauseUseCaseImpl : StatusGameIsGameInPauseUseCase
{
    
    private StatusGameRepository repo = new StatusGameRepositoryImpl();

    public bool invoke() => repo.isGameInPause();
}