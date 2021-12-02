using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetFinalLaserUseCase {
    LaserPlayer invoke();
}

public class SpacecraftPlayerGetFinalLaserUseCaseImpl : SpacecraftPlayerGetFinalLaserUseCase {

    private SpacecraftPlayerLaserRepository repo = new SpacecraftPlayerLaserRepositoryImpl();

    public LaserPlayer invoke() => repo.finalLaser;
}