using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatusGameGetCurrentStatusUseCase
{
    StatusGame invoke();
}

public class StatusGameGetCurrentStatusUseCaseImpl : StatusGameGetCurrentStatusUseCase{

    private StatusGameRepository repo = new StatusGameRepositoryImpl();

    public StatusGame invoke() => repo.getCurrentStatus();
}