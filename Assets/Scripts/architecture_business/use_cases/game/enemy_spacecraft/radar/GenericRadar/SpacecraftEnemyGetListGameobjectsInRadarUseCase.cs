using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetListGameobjectsInRadarUseCase {
    List<GameObject> invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyGetListGameobjectsInRadarUseCaseImpl : SpacecraftEnemyGetListGameobjectsInRadarUseCase
{
    private SpacecraftEnemyRadarRepository repo = new SpacecraftEnemyRadarRepositoryImpl();

    public List<GameObject> invoke(IdentificatorModel identificator) => repo.gameObjectsInRadar(identificator);
}