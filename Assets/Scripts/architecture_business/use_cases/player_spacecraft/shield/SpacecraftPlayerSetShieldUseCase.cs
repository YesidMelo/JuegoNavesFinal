using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerSetShieldUseCase {
    void invoke(ShieldPlayer shieldPlayer);
}

public class SpacecraftPlayerSetShieldUseCaseImpl : SpacecraftPlayerSetShieldUseCase
{

    private SpacecraftPlayerShieldRepository repo = new SpacecraftPlayerShieldRepositoryImpl();

    public void invoke(ShieldPlayer shieldPlayer) => repo.setShield(shieldPlayer);
}