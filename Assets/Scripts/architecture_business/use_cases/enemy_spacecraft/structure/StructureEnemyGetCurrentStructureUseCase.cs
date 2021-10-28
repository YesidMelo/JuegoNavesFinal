using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StructureEnemyGetCurrentStructureUseCase {
    StructureEnemy invoke(IdentificatorModel identificator);
}
public class StructureEnemyGetCurrentStructureUseCaseImpl : StructureEnemyGetCurrentStructureUseCase
{
    private SpacecraftEnemyStructureRepository repo = new SpacecraftEnemyStructureRepositoryImpl();
    public StructureEnemy invoke(IdentificatorModel identificator) => repo.currentStructure(identificator);
}
