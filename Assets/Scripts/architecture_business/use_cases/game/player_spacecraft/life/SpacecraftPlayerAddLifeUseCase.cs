using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerAddLifeUseCase {
    public void invoke();
}

public class SpacecraftPlayerAddLifeUseCaseImpl : SpacecraftPlayerAddLifeUseCase
{
    private SpacecraftPlayerLifeRepository lifeRepository = new SpacecraftPlayerLifeRepositoryImpl();
    private SpacecraftPlayerLifeSupportRepository lifeSupportRepository = new SpacecraftPlayerLifeSupportRepositoryImpl();
    public void invoke() {
        float maxLife = lifeRepository.maxLife;
        float nextRestore = maxLife * lifeSupportRepository.getCurrentLifeSupport().percentageOfRepair();
        lifeRepository.addLife(nextRestore);
    }
}
