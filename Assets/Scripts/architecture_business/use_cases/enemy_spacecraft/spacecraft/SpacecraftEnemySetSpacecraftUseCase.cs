using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemySetSpacecraftUseCase {
    void invoke(IdentificatorModel identificator, SpacecraftEnemy spacecraft);
}

public class SpacecraftEnemySetSpacecraftUseCaseImpl : SpacecraftEnemySetSpacecraftUseCase
{
    private SpacecraftEnemyRepository repo = new SpacecraftEnemyRepositoryImpl();
    public void invoke(IdentificatorModel identificator, SpacecraftEnemy spacecraft) => repo.setSpacecraft(identificator, spacecraft);

}