using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerUpdateRadarUseCase {
    void invoke(RadarPlayer radar);
}
public class SpacecraftPlayerUpdateRadarUseCaseImpl : SpacecraftPlayerUpdateRadarUseCase
{
    private SpacecraftPlayerRadarRepository repo = new SpacecraftPlayerRadarRepositoryImpl();
    public void invoke(RadarPlayer radar) => repo.updateCurrentRadarPlayer(radar);
}