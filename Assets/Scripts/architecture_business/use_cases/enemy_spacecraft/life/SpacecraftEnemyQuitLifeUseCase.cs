using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyQuitLifeUseCase {
    void invoke(IdentificatorModel identificator,int life);
}

public class SpacecraftEnemyQuitLifeUseCaseImpl : SpacecraftEnemyQuitLifeUseCase
{
    public SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();
    public void invoke(IdentificatorModel identificator, int life) => repo.quitLife(identificator, life);
}