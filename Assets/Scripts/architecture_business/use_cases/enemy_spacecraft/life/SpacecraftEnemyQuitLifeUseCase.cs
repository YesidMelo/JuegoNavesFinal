using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyQuitLifeUseCase {
    void invoke(float life, IdentificatorModel identificatorModel);
}
public class SpacecraftEnemyQuitLifeUseCaseImpl : SpacecraftEnemyQuitLifeUseCase
{
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();
    public void invoke(float life, IdentificatorModel identificatorModel) => repo.quitLife(life, identificatorModel);
}