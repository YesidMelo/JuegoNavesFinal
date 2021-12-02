using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LevelGetCurrentLevelUseCase {
    Level invoke();
}
public class LevelGetCurrentLevelUseCaseImpl : LevelGetCurrentLevelUseCase
{
    private LevelRepository repository = new LevelRepositoryImpl();

    public Level invoke() => repository.getCurrentLevel;
}