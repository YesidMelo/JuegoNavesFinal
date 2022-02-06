using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLifeIsMaxLifeUseCase {
    bool invoke();
}

public class SpacecraftPlayerLifeIsMaxLifeUseCaseImpl : SpacecraftPlayerLifeIsMaxLifeUseCase
{
    private SpacecraftPlayerLifeRepository lifeRepository = new SpacecraftPlayerLifeRepositoryImpl();

    public bool invoke() => lifeRepository.lifeIsMaxLife();
}