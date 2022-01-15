using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LevelCache { 
    Level getCurrentLevel { get; }
    void updateLevel(Level level);
    void clearCache();
}

public class LevelCacheImpl : LevelCache
{
    //static variables
    private static LevelCacheImpl instance;

    //static methods

    public static LevelCacheImpl getInstance() {
        if (instance == null) {
            instance = new LevelCacheImpl();
        }
        return instance;
    }

    private Level _currentLevel;

    public Level getCurrentLevel => _currentLevel;

    public void updateLevel(Level level) => _currentLevel = level;

    public void clearCache() => _currentLevel = Level.LEVEL1_SECTION1;
}
