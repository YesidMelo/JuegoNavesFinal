using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRemoveRadarUseCase {
    void invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyRemoveRadarUseCaseImpl : SpacecraftEnemyRemoveRadarUseCase
{
    private SpacecraftEnemyRadarRepository repo = new SpacecraftEnemyRadarRepositoryImpl();
    public void invoke(IdentificatorModel identificator) => repo.removeRadar(identificator);
}