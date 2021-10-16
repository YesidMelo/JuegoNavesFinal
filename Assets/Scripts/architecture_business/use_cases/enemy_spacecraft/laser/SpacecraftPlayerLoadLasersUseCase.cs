using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLoadLasersUseCase
{
    bool invoke(); 
}

public class SpacecraftPlayerLoadLasersUseCaseImpl : SpacecraftPlayerLoadLasersUseCase
{
    private SpacecraftPlayerLaserRepository repo = new SpacecraftPlayerLaserRepositoryImpl();
    public bool invoke() => repo.loadLasers();
}
