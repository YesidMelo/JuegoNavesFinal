public interface StatusGameRestoreSpacecraftUseCase {
    void invoke();
}

public class StatusGameRestoreSpacecraftUseCaseImpl : StatusGameRestoreSpacecraftUseCase
{
    private SpacecraftPlayerLifeRepository lifeRepository = new SpacecraftPlayerLifeRepositoryImpl();
    private StatusGameRepository statusGameRepository = new StatusGameRepositoryImpl();

    public void invoke()
    {
        lifeRepository.restoreLife();
        statusGameRepository.updateStatusGame(status: StatusGame.IN_GAME);
    }
}