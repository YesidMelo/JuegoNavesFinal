using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface DeleteCurrentPlayerUseCase {
    Task invoke();
}

public class DeleteCurrentPlayerUseCaseImpl : DeleteCurrentPlayerUseCase
{
    private InteractionInterfaceUserRepository interactionInterfaceRepository = new InteractionInterfaceUserRepositoryImpl();

    public async Task invoke() => await interactionInterfaceRepository.deleteCurrentPlayer();
}