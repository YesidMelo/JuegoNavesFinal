using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationAddEnemyUseCase {
    void invoke(Level level, SpacecraftEnemy spacecraftEnemy, GameObject gameObject);
}
public class StagePopulationAddEnemyUseCaseImpl : StagePopulationAddEnemyUseCase
{
    private StagePopulationRepository repo = new StagePopulationRepositoryImpl();

    public void invoke(
        Level level,
        SpacecraftEnemy spacecraftEnemy,
        GameObject gameObject
    ) => repo.addEnemy(
        level: level,
        spacecraft: spacecraftEnemy,
        gameObject: gameObject
    );
}