using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyCurrentShieldUseCase {
    ShieldEnemy invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyCurrentShieldUseCaseImpl : SpacecraftEnemyCurrentShieldUseCase
{
    private SpacecraftEnemyShieldRepository repo = new SpacecraftEnemyShieldRepositoryImpl();

    public ShieldEnemy invoke(IdentificatorModel identificator) => repo.currentShield(identificator);
}