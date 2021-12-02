using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRemoveGameobjectFromRadarUseCase {
    void invoke(IdentificatorModel identificator, GameObject gameObject);
}
public class SpacecraftEnemyRemoveGameobjectFromRadarUseCaseImpl : SpacecraftEnemyRemoveGameobjectFromRadarUseCase
{
    private SpacecraftEnemyRadarRepository repo = new SpacecraftEnemyRadarRepositoryImpl();

    public void invoke(IdentificatorModel identificator, GameObject gameObject) => repo.removeGameobjectFromRadar(identificator, gameObject);
}