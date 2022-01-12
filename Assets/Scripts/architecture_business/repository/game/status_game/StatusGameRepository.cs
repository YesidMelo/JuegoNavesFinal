using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatusGameRepository {
    void updateStatusGame(StatusGame status);
    StatusGame getCurrentStatus();
    bool isGameInPause();
}

public class StatusGameRepositoryImpl : StatusGameRepository
{

    private StatusGameDatasourceCache cache = StatusGameDatasourceCacheImpl.getInstance();

    public StatusGame getCurrentStatus() => cache.getCurrentStatus();

    public bool isGameInPause() => cache.isGameInPause();

    public void updateStatusGame(StatusGame status) => cache.updateStatusGame(status: status);
}