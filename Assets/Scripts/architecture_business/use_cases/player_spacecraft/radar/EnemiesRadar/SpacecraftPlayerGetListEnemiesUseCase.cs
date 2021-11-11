using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetListEnemiesUseCase {
    List<GameObject> invoke();
}
public class SpacecraftPlayerGetListEnemiesUseCaseImpl : SpacecraftPlayerGetListEnemiesUseCase
{
    private SpacecraftPlayerRadarRepository repository = new SpacecraftPlayerRadarRepositoryImpl();

    public List<GameObject> invoke() => repository.getListEnemies;
}