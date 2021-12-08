using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DeleteAllEnemiesUseCase {
    void invoke(List<GameObject> enemies);
}
public class DeleteAllEnemiesUseCaseImpl : DeleteAllEnemiesUseCase
{
    private StagePopulationRepository populationRepository = new StagePopulationRepositoryImpl();

    public void invoke(List<GameObject> enemies) => populationRepository.removeAllEnemies(enemies: enemies);
}
