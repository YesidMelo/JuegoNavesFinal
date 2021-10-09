using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetFinalLaserUseCase {
    Laser invoke();
}

public class SpacecraftPlayerGetFinalLaserUseCaseImpl : SpacecraftPlayerGetFinalLaserUseCase {

    private SpacecraftPlayerLaserRepository repo = new SpacecraftPlayerLaserRepositoryImpl();

    public Laser invoke() => repo.finalLaser;
}