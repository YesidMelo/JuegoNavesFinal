using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCurrentPlayerUseCase {
    GameObject invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyCurrentPlayerUseCaseImpl : SpacecraftEnemyCurrentPlayerUseCase
{
    private SpacecraftEnemyRadarRepository repo = new SpacecraftEnemyRadarRepositoryImpl();

    public GameObject invoke(IdentificatorModel identificator) => repo.currentPlayer(identificator);
    
}