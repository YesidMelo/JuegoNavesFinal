using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SetCurrentPlayerUseCase {
    void invoke(GameObject currentPlayer);
}
public class SetCurrentPlayerUseCaseImpl : SetCurrentPlayerUseCase
{
    private InteractionInterfaceUserRepository interfaceUserRepository = new InteractionInterfaceUserRepositoryImpl();

    public void invoke(GameObject currentPlayer) => interfaceUserRepository.setCurrentPlayer(currentPlayer: currentPlayer);
}
