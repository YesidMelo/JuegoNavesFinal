using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemySetMaxLifeUseCase {
    void invoke(float maxLife, IdentificatorModel identificatorModel);
}
public class SpacecraftEnemySetMaxLifeUseCaseImpl : SpacecraftEnemySetMaxLifeUseCase
{
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();

    public void invoke(float maxLife, IdentificatorModel identificatorModel) => repo.setMaxLife(maxLife, identificatorModel);
}