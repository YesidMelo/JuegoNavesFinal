using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLoadRadarUseCase {
    bool invoke();
}
public class SpacecraftPlayerLoadRadarUseCaseImpl : SpacecraftPlayerLoadRadarUseCase
{
    private SpacecraftPlayerRadarRepository repo = new SpacecraftPlayerRadarRepositoryImpl();
    public bool invoke() => repo.loadElementsRadar();
}