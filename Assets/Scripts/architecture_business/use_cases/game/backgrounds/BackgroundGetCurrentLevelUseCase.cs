public interface BackgroundGetCurrentLevelUseCase {
    Level invoke();
}

public class BackgroundGetCurrentLevelUseCaseImpl : BackgroundGetCurrentLevelUseCase
{
    private BackgrounRepository repo = new BackgrounRepositoryImpl();

    public Level invoke() => repo.getCurrentLevel();

}
