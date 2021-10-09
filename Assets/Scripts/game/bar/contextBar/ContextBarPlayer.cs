using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextBarPlayer : BaseContextBar
{
    private SpacecraftPlayerGetMaxLifeUseCase maxLifeUseCase = new SpacecraftPlayerGetMaxLifeUseCaseImpl();
    private SpacecraftPlayerGetLifeUseCase lifeUseCase = new SpacecraftPlayerGetLifeUseCaseImpl();

    public ContextBarPlayer(HandlerPositionBarInSpacecraft handlerPositionBar) : base(handlerPositionBar){}

    public override float maxLife => maxLifeUseCase.invoke();

    public override float life => lifeUseCase.invoke();
}
