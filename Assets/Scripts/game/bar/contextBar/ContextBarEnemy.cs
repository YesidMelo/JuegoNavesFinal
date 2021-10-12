using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextBarEnemy : BaseContextBar
{
    private SpacecraftEnemyGetMaxLifeUseCase maxLifeUseCase = new SpacecraftEnemyGetMaxLifeUseCaseImpl();
    private SpacecraftEnemyGetLifeUseCase lifeUseCase = new SpacecraftEnemyGetLifeUseCaseImpl();
    private IdentificatorModel _identificator;
    public ContextBarEnemy(
        HandlerPositionBarInSpacecraft handlerPositionBar,
        IdentificatorModel identificatorModel
    ) : base(handlerPositionBar){
        _identificator = identificatorModel;
    }

    public override float maxLife => maxLifeUseCase.invoke(_identificator);

    public override float life => lifeUseCase.invoke(_identificator);
}
