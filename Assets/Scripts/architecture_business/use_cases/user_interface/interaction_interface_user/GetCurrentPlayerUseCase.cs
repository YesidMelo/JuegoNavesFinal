using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GetCurrentPlayerUseCase {
    GameObject invoke();
}

public class GetCurrentPlayerUseCaseImpl : GetCurrentPlayerUseCase
{
    private InteractionInterfaceUserRepository interfaceUserRepository = new InteractionInterfaceUserRepositoryImpl();

    public GameObject invoke() => interfaceUserRepository.currentPlayer;
}