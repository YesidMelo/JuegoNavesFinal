using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetCurrentRadiusRadarUseCase {
    float invoke();
}
public class SpacecraftPlayerGetCurrentRadiusRadarUseCaseImpl : SpacecraftPlayerGetCurrentRadiusRadarUseCase
{
    private SpacecraftPlayerRadarRepository repo = new SpacecraftPlayerRadarRepositoryImpl();

    public float invoke() => repo.currentRadiusRadar;
}