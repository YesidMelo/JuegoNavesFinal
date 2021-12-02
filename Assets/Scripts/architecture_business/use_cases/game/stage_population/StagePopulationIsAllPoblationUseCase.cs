using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StagePopulationIsAllPoblationUseCase {
    bool invoke(Level level);
}

public class StagePopulationIsAllPoblationUseCaseImpl : StagePopulationIsAllPoblationUseCase
{
    private StagePopulationRepository repo = new StagePopulationRepositoryImpl();

    public bool invoke(Level level) => repo.isAllPoblation(level: level);
}