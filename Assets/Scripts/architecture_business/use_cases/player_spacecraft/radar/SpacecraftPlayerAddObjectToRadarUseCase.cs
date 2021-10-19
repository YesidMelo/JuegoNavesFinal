using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerAddObjectToRadarUseCase {
    void invoke(GameObject gameObject);
}
public class SpacecraftPlayerAddObjectToRadarUseCaseImpl : SpacecraftPlayerAddObjectToRadarUseCase
{
    private SpacecraftPlayerRadarRepository repo = new SpacecraftPlayerRadarRepositoryImpl();
    public void invoke(GameObject gameObject) => repo.addElementToRadar(gameObject);
}