using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetCurrentEnemyUseCase {
    GameObject invoke();
}
public class SpacecraftPlayerGetCurrentEnemyUseCaseImpl : SpacecraftPlayerGetCurrentEnemyUseCase
{
    private SpacecraftPlayerRadarRepository radarRepository = new SpacecraftPlayerRadarRepositoryImpl();
    private InteractionInterfaceUserRepository joysticRepository = new InteractionInterfaceUserRepositoryImpl();

    public GameObject invoke() {
        if (joysticRepository.currentActionSpacecraft != Action.ATTACK) return null;
        if (radarRepository.currentEnemy == null) {
            radarRepository.changeCurrentEnemy();
        }
        return radarRepository.currentEnemy;
    }
}