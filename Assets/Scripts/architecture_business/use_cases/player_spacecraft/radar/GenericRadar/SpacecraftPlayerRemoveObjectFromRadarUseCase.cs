using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerRemoveObjectFromRadarUseCase {
    void invoke(GameObject gameObject);
}
public class SpacecraftPlayerRemoveObjectFromRadarUseCaseImpl : SpacecraftPlayerRemoveObjectFromRadarUseCase
{
    private SpacecraftPlayerRadarRepository repo = new SpacecraftPlayerRadarRepositoryImpl();

    public void invoke(GameObject gameObject) => repo.removeElementFromRadar(gameObject);
}