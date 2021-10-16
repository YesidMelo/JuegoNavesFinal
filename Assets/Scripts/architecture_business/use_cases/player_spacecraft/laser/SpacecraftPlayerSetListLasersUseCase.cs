using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerSetListLasersUseCase 
{
    public void invoke(List<LaserPlayer> listLasers);
}

public class SpacecraftPlayerSetListLasersUseCaseImpl : SpacecraftPlayerSetListLasersUseCase
{
    private SpacecraftPlayerLaserRepository repo = new SpacecraftPlayerLaserRepositoryImpl();

    public void invoke(List<LaserPlayer> listLasers) => repo.setListLaser(listLasers);
}
