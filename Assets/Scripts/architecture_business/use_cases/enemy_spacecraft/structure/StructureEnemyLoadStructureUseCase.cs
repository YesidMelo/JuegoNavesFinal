using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StructureEnemyLoadStructureUseCase {
    bool invoke(IdentificatorModel identificator);
}
public class StructureEnemyLoadStructureUseCaseImpl : StructureEnemyLoadStructureUseCase
{
    
    private SpacecraftEnemyRepository repositorySpacecraft = new SpacecraftEnemyRepositoryImpl();
    private SpacecraftEnemyStructureRepository repositoryStructure = new SpacecraftEnemyStructureRepositoryImpl();

    public bool invoke(IdentificatorModel identificator)
    {
        SpacecraftEnemy currentSpacecraft = repositorySpacecraft.currentSpacecraft(identificator);
        return repositoryStructure.loadStructure(identificator, currentSpacecraft);
    }
}