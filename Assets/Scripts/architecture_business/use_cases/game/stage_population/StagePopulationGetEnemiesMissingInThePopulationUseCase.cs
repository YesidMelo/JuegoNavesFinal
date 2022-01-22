using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationGetEnemiesMissingInThePopulationUseCase {
    int invoke(SpacecraftEnemy enemy);
}
public class StagePopulationGetEnemiesMissingInThePopulationUseCaseImpl : StagePopulationGetEnemiesMissingInThePopulationUseCase
{
    private StagePopulationRepository repo = new StagePopulationRepositoryImpl();
    private LevelRepository levelRepository = new LevelRepositoryImpl();

    public int invoke(SpacecraftEnemy enemy) => repo.getEnemiesMissingInThePopulation(
        level: levelRepository.getCurrentLevel,
        enemy: enemy
    );
}