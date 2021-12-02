using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerCurrentRadarUseCase {
    RadarPlayer invoke();
}
public class SpacecraftPlayerCurrentRadarUseCaseImpl : SpacecraftPlayerCurrentRadarUseCase
{
    private SpacecraftPlayerRadarRepository repo = new SpacecraftPlayerRadarRepositoryImpl();
    public RadarPlayer invoke() => repo.currentRadarPlayer;
}