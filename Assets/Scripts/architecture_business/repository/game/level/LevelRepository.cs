using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LevelRepository {
    Level getCurrentLevel { get; }
    void updateLevel(Level level);
}
public class LevelRepositoryImpl : LevelRepository
{
    private LevelCache cache = LevelCacheImpl.getInstance();

    public Level getCurrentLevel => cache.getCurrentLevel;

    public void updateLevel(Level level) => cache.updateLevel(level);
}