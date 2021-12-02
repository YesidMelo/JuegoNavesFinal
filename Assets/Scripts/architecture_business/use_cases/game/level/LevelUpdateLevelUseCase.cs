using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LevelUpdateLevelUseCase {
    void invoke(Level level);
}

public class LevelUpdateLevelUseCaseImpl : LevelUpdateLevelUseCase
{
    private LevelRepository repo = new LevelRepositoryImpl();
    public void invoke(Level level) => repo.updateLevel(level: level);
}