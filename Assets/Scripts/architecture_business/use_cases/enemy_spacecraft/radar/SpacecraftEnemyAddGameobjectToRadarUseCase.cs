using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyAddGameobjectToRadarUseCase {
    void invoke(IdentificatorModel identificator, GameObject gameObject);
}
public class SpacecraftEnemyAddGameobjectToRadarUseCaseImpl : SpacecraftEnemyAddGameobjectToRadarUseCase
{
    private SpacecraftEnemyRadarRepository repo = new SpacecraftEnemyRadarRepositoryImpl();
    public void invoke(IdentificatorModel identificator, GameObject gameObject) => repo.addGameobjectToRadar(identificator, gameObject);
}