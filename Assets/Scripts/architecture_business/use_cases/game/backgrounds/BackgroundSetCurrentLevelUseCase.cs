using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BackgroundSetCurrentLevelUseCase {
    void invoke(Level level);
}

public class BackgroundSetCurrentLevelUseCaseImpl : BackgroundSetCurrentLevelUseCase
{

    private BackgrounRepository repo = new BackgrounRepositoryImpl();
    public void invoke(Level level) => repo.setCurrentLevel(level: level);
}
