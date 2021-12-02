using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRemoveLifeUseCase {
    void invoke(IdentificatorModel identificator);
}

public class SpacecraftEnemyRemoveLifeUseCaseImpl : SpacecraftEnemyRemoveLifeUseCase
{
    private SpacecraftEnemyLifeRepository repo = new SpacecraftEnemyLifeRepositoryImpl();
    public void invoke(IdentificatorModel identificator) => repo.removeLife(identificator);
}