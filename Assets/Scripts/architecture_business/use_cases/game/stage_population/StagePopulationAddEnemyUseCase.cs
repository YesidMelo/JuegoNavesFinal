using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationAddEnemyUseCase {
    void invoke(SpacecraftEnemy spacecraftEnemy, GameObject gameObject);
}
public class StagePopulationAddEnemyUseCaseImpl : StagePopulationAddEnemyUseCase
{
    private StagePopulationRepository repo = new StagePopulationRepositoryImpl();
    private LevelRepository levelRepository = new LevelRepositoryImpl();

    public void invoke(
        SpacecraftEnemy spacecraftEnemy,
        GameObject gameObject
    ) => repo.addEnemy(
        level: levelRepository.getCurrentLevel,
        spacecraft: spacecraftEnemy,
        gameObject: gameObject
    );
}