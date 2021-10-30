using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpacecraftEnemyAddLifeUseCase {
    void invoke(IdentificatorModel identificator, int life);
}

public class SpacecraftEnemyAddLifeUseCaseImpl : ISpacecraftEnemyAddLifeUseCase
{
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();

    public void invoke(IdentificatorModel identificator, int life) => repo.addLife(identificator, life);
}