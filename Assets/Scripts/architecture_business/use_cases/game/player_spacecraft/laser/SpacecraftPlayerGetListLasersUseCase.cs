using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetListLasersUseCase {
    List<LaserPlayer> invoke();
}

public class SpacecraftPlayerGetListLasersUseCaseImpl : SpacecraftPlayerGetListLasersUseCase {

    private SpacecraftPlayerLaserRepository repo = new SpacecraftPlayerLaserRepositoryImpl();

    public List<LaserPlayer> invoke() => repo.listLasers;
}