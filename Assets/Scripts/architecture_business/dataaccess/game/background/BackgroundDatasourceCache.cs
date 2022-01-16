public interface BackgroundDatasourceCache {
    void setCurrentLevel(Level level);
    Level getCurrentLevel();
}

public class BackgroundDatasourceCacheImpl : BackgroundDatasourceCache {
    // static variables
    private static BackgroundDatasourceCache _instance;

    // static methods
    public static BackgroundDatasourceCache getInstance() {
        if (_instance == null) {
            _instance = new BackgroundDatasourceCacheImpl();
        }
        return _instance;
    }

    private Level _currentLevel = Level.LEVEL1_SECTION1;

    private BackgroundDatasourceCacheImpl() { }

    public void setCurrentLevel(Level level) => _currentLevel = level;

    public Level getCurrentLevel() => _currentLevel;

}