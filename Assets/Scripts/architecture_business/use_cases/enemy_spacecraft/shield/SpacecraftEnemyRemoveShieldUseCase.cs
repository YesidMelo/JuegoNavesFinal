using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyRemoveShieldUseCase {
    void invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyRemoveShieldUseCaseImpl : SpacecraftEnemyRemoveShieldUseCase
{
    private SpacecraftEnemyShieldRepository repo = new SpacecraftEnemyShieldRepositoryImpl();
    public void invoke(IdentificatorModel identificator) => repo.removeShield(identificator);
}