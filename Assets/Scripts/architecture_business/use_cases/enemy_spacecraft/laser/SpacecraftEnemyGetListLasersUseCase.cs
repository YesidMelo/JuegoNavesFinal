using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyGetListLasersUseCase {
    List<Laser> invoke(IdentificatorModel identificatorModel);
}

public class SpacecraftEnemyGetListLasersUseCaseImpl : SpacecraftEnemyGetListLasersUseCase
{
    private SpacecraftEnemyLaserRepository repo = new SpacecraftEnemyLaserRepositoryImpl();

    public List<Laser> invoke(IdentificatorModel identificatorModel) => repo.listLasers(identificatorModel);
}
