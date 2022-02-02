using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatusGameIsGameChangedLevelUseCase {
    bool invoke();
}

public class StatusGameIsGameChangedLevelUseCaseImpl : StatusGameIsGameChangedLevelUseCase
{
    private StatusGameRepository statusGameRepository = new StatusGameRepositoryImpl();

    public bool invoke() => statusGameRepository.isGameChagedLevel();
}