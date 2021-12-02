using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerCurrentShieldUseCase {
    ShieldPlayer invoke();
}

public class SpacecraftPlayerCurrentShieldUseCaseImpl : SpacecraftPlayerCurrentShieldUseCase
{

    private SpacecraftPlayerShieldRepository repo = new SpacecraftPlayerShieldRepositoryImpl();

    public ShieldPlayer invoke() => repo.currentShield;
}