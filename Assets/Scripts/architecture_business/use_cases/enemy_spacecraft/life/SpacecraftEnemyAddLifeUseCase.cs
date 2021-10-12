using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyAddLifeUseCase {
    void invoke(float life, IdentificatorModel identificatorModel);
}
public class SpacecraftEnemyAddLifeUseCaseImpl : SpacecraftEnemyAddLifeUseCase
{
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();

    public void invoke(float life, IdentificatorModel identificatorModel) => repo.addLife(life, identificatorModel);
}