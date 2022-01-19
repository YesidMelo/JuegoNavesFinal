using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BackgroundSetCurrentLevelUseCase {
    void invoke(Level level);
}

public class BackgroundSetCurrentLevelUseCaseImpl : BackgroundSetCurrentLevelUseCase
{

    private LevelRepository repo = new LevelRepositoryImpl();
    public void invoke(Level level) => repo.updateLevel(level: level);
}
