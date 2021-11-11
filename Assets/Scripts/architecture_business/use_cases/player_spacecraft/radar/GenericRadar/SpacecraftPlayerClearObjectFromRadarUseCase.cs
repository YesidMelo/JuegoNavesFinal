using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerClearObjectFromRadarUseCase {
    void invoke();
}
public class SpacecraftPlayerClearObjectFromRadarUseCaseImpl : SpacecraftPlayerClearObjectFromRadarUseCase
{
    private SpacecraftPlayerRadarRepository repo = new SpacecraftPlayerRadarRepositoryImpl();

    public void invoke() => repo.clearElementsRadar();
}