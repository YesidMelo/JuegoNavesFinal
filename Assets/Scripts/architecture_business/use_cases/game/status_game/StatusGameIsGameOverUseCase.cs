using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatusGameIsGameOverUseCase {
    bool invoke();
}

public class StatusGameIsGameOverUseCaseImpl : StatusGameIsGameOverUseCase
{
    private StatusGameRepository repo = new StatusGameRepositoryImpl();
    public bool invoke() => repo.isGameOver();
}