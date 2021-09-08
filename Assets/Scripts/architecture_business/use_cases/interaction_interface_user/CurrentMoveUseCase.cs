using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CurrentMoveUseCase {
    public Move invoke();
}
public class CurrentMoveUseCaseImpl : CurrentMoveUseCase
{
    private InteractionInterfaceRepository interactionInterfaceRepository = InteractionInterfaceRepositoryImpl.getInstance();

    public Move invoke() => interactionInterfaceRepository.getCurrentMove();
}
