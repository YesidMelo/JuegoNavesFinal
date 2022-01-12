using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatusGameUpdateStatusUseCase
{
    void invoke(StatusGame statusGame);
}

public class StatusGameUpdateStatusUseCaseImpl : StatusGameUpdateStatusUseCase
{
    private StatusGameRepository repository = new StatusGameRepositoryImpl();

    public void invoke(StatusGame statusGame) => repository.updateStatusGame(status: statusGame);
}
