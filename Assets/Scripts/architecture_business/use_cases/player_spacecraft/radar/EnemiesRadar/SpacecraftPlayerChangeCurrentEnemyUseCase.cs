using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerChangeCurrentEnemyUseCase {
    void invoke();
}

public class SpacecraftPlayerChangeCurrentEnemyUseCaseImpl : SpacecraftPlayerChangeCurrentEnemyUseCase
{
    private SpacecraftPlayerRadarRepository radarRepository = new SpacecraftPlayerRadarRepositoryImpl();

    public void invoke() => radarRepository.changeCurrentEnemy();
}