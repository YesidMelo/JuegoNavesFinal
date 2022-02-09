using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpacecraftPlayerLifeSupportPlayerIsUnderAttackUseCase {
    bool invoke();
}

public class SpacecraftPlayerLifeSupportPlayerIsUnderAttackUseCaseImpl : SpacecraftPlayerLifeSupportPlayerIsUnderAttackUseCase
{
    
    private SpacecraftPlayerLifeSupportRepository lifeSupportRepository = new SpacecraftPlayerLifeSupportRepositoryImpl();

    public bool invoke() => lifeSupportRepository.playerIsUnderAttack();
}