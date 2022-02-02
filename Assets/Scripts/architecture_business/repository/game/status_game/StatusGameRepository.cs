using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatusGameRepository {
    void updateStatusGame(StatusGame status);
    StatusGame getCurrentStatus();
    bool isGameInPause();
    bool isGameOver();
    bool isGameChagedLevel();
}

public class StatusGameRepositoryImpl : StatusGameRepository
{

    private StatusGameDatasourceCache cache = StatusGameDatasourceCacheImpl.getInstance();

    public StatusGame getCurrentStatus() => cache.getCurrentStatus();

    public bool isGameChagedLevel() => cache.isGameChagedLevel();

    public bool isGameInPause() => cache.isGameInPause();

    public bool isGameOver() => cache.isGameOver();

    public void updateStatusGame(StatusGame status) => cache.updateStatusGame(status: status);
}