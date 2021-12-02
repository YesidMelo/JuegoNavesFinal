using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StructureEnemyDeleteStructureUseCase {
    void invoke(IdentificatorModel identificator);
}
public class StructureEnemyDeleteStructureUseCaseImpl : StructureEnemyDeleteStructureUseCase
{
    private SpacecraftEnemyStructureRepository repoStructure = new SpacecraftEnemyStructureRepositoryImpl();

    public void invoke(IdentificatorModel identificator) => repoStructure.deleteStructure(identificator);
}
