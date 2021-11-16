using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationGetEnemiesMissingInThePopulationUseCase {
    Dictionary<SpacecraftEnemy, int> invoke(Level level);
}
public class StagePopulationGetEnemiesMissingInThePopulationUseCaseImpl : StagePopulationGetEnemiesMissingInThePopulationUseCase
{
    private StagePopulationRepository repo = new StagePopulationRepositoryImpl();

    public Dictionary<SpacecraftEnemy, int> invoke(Level level) => repo.getEnemiesMissingInThePopulation(level: level);
}