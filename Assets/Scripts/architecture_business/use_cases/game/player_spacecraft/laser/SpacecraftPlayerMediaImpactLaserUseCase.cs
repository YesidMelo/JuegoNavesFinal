using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerMediaImpactLaserUseCase {
    float invoke();
}

public class SpacecraftPlayerMediaImpactLaserUseCaseImpl : SpacecraftPlayerMediaImpactLaserUseCase
{
    private SpacecraftPlayerLaserRepository repo = new SpacecraftPlayerLaserRepositoryImpl();
    public float invoke() => repo.mediaImpactLaser;
}
