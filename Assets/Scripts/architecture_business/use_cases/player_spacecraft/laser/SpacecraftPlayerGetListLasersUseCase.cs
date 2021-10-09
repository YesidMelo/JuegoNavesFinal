using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerGetListLasersUseCase {
    List<Laser> invoke();
}

public class SpacecraftPlayerGetListLasersUseCaseImpl : SpacecraftPlayerGetListLasersUseCase {

    private SpacecraftPlayerLaserRepository repo = new SpacecraftPlayerLaserRepositoryImpl();

    public List<Laser> invoke() => repo.listLasers;
}