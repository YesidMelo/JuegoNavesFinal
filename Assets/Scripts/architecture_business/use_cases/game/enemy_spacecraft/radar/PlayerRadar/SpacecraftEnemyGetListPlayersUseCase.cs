using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetListPlayersUseCase {
    List<GameObject> invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyGetListPlayersUseCaseImpl : SpacecraftEnemyGetListPlayersUseCase
{
    private SpacecraftEnemyRadarRepository repo = new SpacecraftEnemyRadarRepositoryImpl();

    public List<GameObject> invoke(IdentificatorModel identificator) => repo.getListPlayers(identificator);
}