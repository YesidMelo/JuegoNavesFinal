public interface StatusGameDatasourceCache {
    void updateStatusGame(StatusGame status);
    StatusGame getCurrentStatus();
    bool isGameInPause();
    bool isGameOver();
    bool isGameChagedLevel();
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
    private bool _isGameInPause = false;
    private bool _isGameOver = false;
    private bool _isGameChangedLevel = false;

    public StatusGame getCurrentStatus() => _currentStatusGame;
    public void updateStatusGame(StatusGame status) {
        _currentStatusGame = status;
        _isGameInPause = status != StatusGame.IN_GAME;
        _isGameOver = status == StatusGame.GAME_OVER;
        _isGameChangedLevel = status == StatusGame.CHANGE_LEVEL;
    }

    public bool isGameInPause() => _isGameInPause;

    public bool isGameOver() => _isGameOver;

    public bool isGameChagedLevel() => _isGameChangedLevel;
}