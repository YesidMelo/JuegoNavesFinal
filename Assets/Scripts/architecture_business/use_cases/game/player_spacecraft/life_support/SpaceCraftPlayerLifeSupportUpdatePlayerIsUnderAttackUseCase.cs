using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpaceCraftPlayerLifeSupportUpdatePlayerIsUnderAttackUseCase {
    void invoke(bool playerIsUnderAttack);
}

public class SpaceCraftPlayerLifeSupportUpdatePlayerIsUnderAttackUseCaseImpl : SpaceCraftPlayerLifeSupportUpdatePlayerIsUnderAttackUseCase
{
    private SpacecraftPlayerLifeSupportRepository lifeSupportRepository = new SpacecraftPlayerLifeSupportRepositoryImpl();

    public void invoke(bool playerIsUnderAttack) => lifeSupportRepository.updatePlayerIsUnderAttack(playerIsUnderAttack: playerIsUnderAttack);
}