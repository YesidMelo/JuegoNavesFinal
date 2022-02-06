using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LifeSupportPlayerPlayerIsUnderAttackUseCase {
    bool invoke();
}

public class LifeSupportPlayerPlayerIsUnderAttackUseCaseImpl : LifeSupportPlayerPlayerIsUnderAttackUseCase
{
    
    private SpacecraftPlayerLifeSupportRepository lifeSupportRepository = new SpacecraftPlayerLifeSupportRepositoryImpl();

    public bool invoke() => lifeSupportRepository.playerIsUnderAttack();
}