using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BackgrounRepository {
    void setCurrentLevel(Level level);
    Level getCurrentLevel();
}

public class BackgrounRepositoryImpl : BackgrounRepository
{
    private BackgroundDatasourceCache cache = BackgroundDatasourceCacheImpl.getInstance();

    public Level getCurrentLevel() => cache.getCurrentLevel();

    public void setCurrentLevel(Level level) => cache.setCurrentLevel(level: level);
}