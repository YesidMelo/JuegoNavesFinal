using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationIsAllPoblationUseCase {
    bool invoke();
}

public class StagePopulationIsAllPoblationUseCaseImpl : StagePopulationIsAllPoblationUseCase
{
    private readonly StagePopulationRepository repo = new StagePopulationRepositoryImpl();
    private readonly LevelRepository levelRepository = new LevelRepositoryImpl();

    public bool invoke() => repo.isAllPoblation(level: levelRepository.getCurrentLevel);
}