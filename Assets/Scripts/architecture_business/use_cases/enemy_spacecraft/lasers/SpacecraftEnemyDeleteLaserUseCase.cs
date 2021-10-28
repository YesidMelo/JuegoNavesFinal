using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyDeleteLaserUseCase {
    void invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyDeleteLaserUseCaseImpl : SpacecraftEnemyDeleteLaserUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();
    public void invoke(IdentificatorModel identificator) => repo.deleteLasers(identificator);
}