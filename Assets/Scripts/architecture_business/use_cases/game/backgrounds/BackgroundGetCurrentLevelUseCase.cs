public interface BackgroundGetCurrentLevelUseCase {
    Level invoke();
}

public class BackgroundGetCurrentLevelUseCaseImpl : BackgroundGetCurrentLevelUseCase
{
    private LevelRepository repo = new LevelRepositoryImpl();

    public Level invoke() => repo.getCurrentLevel;

}
