using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerMediaImpactLaserUseCase {
    int invoke();
}

public class SpacecraftPlayerMediaImpactLaserUseCaseImpl : SpacecraftPlayerMediaImpactLaserUseCase
{
    private SpacecraftPlayerLaserRepository repo = new SpacecraftPlayerLaserRepositoryImpl();
    public int invoke() => repo.mediaImpactLaser;
}
