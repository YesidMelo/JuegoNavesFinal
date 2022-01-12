public interface StatusGameDatasourceCache {
    void updateStatusGame(StatusGame status);
    StatusGame getCurrentStatus();
    bool isGameInPause();
}

public class StatusGameDatasourceCacheImpl : StatusGameDatasourceCache
{
    //static variables
    private static StatusGameDatasourceCacheImpl instance;

    //static methods
    public static StatusGameDatasourceCacheImpl getInstance() {
        if (instance == null) {
            instance = new StatusGameDatasourceCacheImpl();
        }
        return instance;
    }

    private StatusGameDatasourceCacheImpl() { }

    private StatusGame _currentStatusGame;
    private bool _isGameInPause = true;

    public StatusGame getCurrentStatus() => _currentStatusGame;
    public void updateStatusGame(StatusGame status) {
        _currentStatusGame = status;
        _isGameInPause = status == StatusGame.IN_GAME ? false : true;
    }

    public bool isGameInPause() => _isGameInPause;
}