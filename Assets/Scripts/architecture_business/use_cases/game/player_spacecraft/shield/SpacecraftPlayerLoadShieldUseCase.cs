using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLoadShieldUseCase {
    bool invoke();
}
public class SpacecraftPlayerLoadShieldUseCaseImpl : SpacecraftPlayerLoadShieldUseCase
{

    private SpacecraftPlayerShieldRepository repo = new SpacecraftPlayerShieldRepositoryImpl();

    public bool invoke() => repo.loadShield();
}