using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UpdateCurrentMoveUseCase {

    void invoke(Move move);
}

public class UpdateCurrentMoveUseCaseImpl : UpdateCurrentMoveUseCase
{

    private InteractionInterfaceRepository interactionInterfaceRepository = InteractionInterfaceRepositoryImpl.getInstance();

    public void invoke(Move move) => interactionInterfaceRepository.setCurrentMovement(move);
}
