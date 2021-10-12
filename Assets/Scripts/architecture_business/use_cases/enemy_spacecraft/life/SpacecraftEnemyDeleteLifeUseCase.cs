using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyDeleteLifeUseCase {
    void invoke(IdentificatorModel identificatorModel);
}
public class SpacecraftEnemyDeleteLifeUseCaseImpl : SpacecraftEnemyDeleteLifeUseCase
{
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();
    public void invoke(IdentificatorModel identificatorModel) => repo.deleteLife(identificatorModel);
}