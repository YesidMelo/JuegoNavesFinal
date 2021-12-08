using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GetAllEnemiesUseCase {
    List<GameObject> invoke();
}

public class GetAllEnemiesUseCaseImpl : GetAllEnemiesUseCase
{

    private StagePopulationRepository repo = new StagePopulationRepositoryImpl();

    public List<GameObject> invoke() => repo.getAllEnemies();
}