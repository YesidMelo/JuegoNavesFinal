using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetListObjectsFromRadarUseCase {
    List<GameObject> invoke();
}
public class SpacecraftPlayerGetListObjectsFromRadarUseCaseImpl : SpacecraftPlayerGetListObjectsFromRadarUseCase
{
    private SpacecraftPlayerRadarRepository repo = new SpacecraftPlayerRadarRepositoryImpl();
    public List<GameObject> invoke() => repo.getListObjectsRadar;
}