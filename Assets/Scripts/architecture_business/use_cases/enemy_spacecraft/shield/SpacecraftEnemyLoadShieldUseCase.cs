using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftEnemyLoadShieldUseCase {
    bool invoke(IdentificatorModel identificator);
}
public class SpacecraftEnemyLoadShieldUseCaseImpl : SpacecraftEnemyLoadShieldUseCase
{
    private SpacecraftEnemyShieldRepository repoShield = new SpacecraftEnemyShieldRepositoryImpl();
    private SpacecraftEnemyRepository repoSpacecraft = new SpacecraftEnemyRepositoryImpl();

    public bool invoke(IdentificatorModel identificator) => repoShield.loadShield(identificator, repoSpacecraft.currentSpacecraft(identificator));
}