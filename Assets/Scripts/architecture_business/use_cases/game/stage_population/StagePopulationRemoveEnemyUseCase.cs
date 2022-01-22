using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationRemoveEnemyUseCase {
    void invoke(GameObject gameObject);
}

public class StagePopulationRemoveEnemyUseCaseImpl : StagePopulationRemoveEnemyUseCase
{
    private StagePopulationRepository repo = new StagePopulationRepositoryImpl();
    private LevelRepository levelRepository = new LevelRepositoryImpl();

    public void invoke(GameObject gameObject) => repo.removeEnemy(
        gameObject: gameObject,
        level: levelRepository.getCurrentLevel
    );
}